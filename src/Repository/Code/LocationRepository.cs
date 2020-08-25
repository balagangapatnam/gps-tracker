using Dapper;
using Repository.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Code
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public LocationRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<User> GetCurrentLocationAsync(int userId)
        {

            const string sql = @"
WITH ulh AS
(
    SELECT u.Id
         , u.[Name]
         , ul.Latitude
         , ul.Longitude
         , RANK() OVER(PARTITION BY u.ID
                           ORDER BY ul.ID DESC) AS [rank]
      FROM dbo.[User] u WITH(NOLOCK)
INNER JOIN dbo.UserLocation ul WITH(NOLOCK)
        ON u.Id = ul.UserID
     WHERE u.Id = @userId
)
SELECT  Id, [Name],Latitude, Longitude FROM ulh WHERE [rank] = 1;
";

            using var conn = await _databaseConnectionFactory.CreateConnectionAsync();

            var users = await conn.QueryAsync<User, Location, User>(sql,
                (user, location) =>
                {
                    user.CurrentLocation = location;
                    return user;
                },
                new { userId },
                splitOn: "Latitude");
            return users.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetCurrentLocationForAllUsersAsync()
        {
            const string sql = @"
WITH ulh AS
(
    SELECT u.Id
         , u.[Name]
         , ul.Latitude
         , ul.Longitude
         , RANK() OVER(PARTITION BY u.ID
                           ORDER BY ul.ID DESC) AS [rank]
      FROM dbo.[User] u WITH(NOLOCK)
INNER JOIN dbo.UserLocation ul WITH(NOLOCK)
        ON u.Id = ul.UserID
)
SELECT Id, [Name], Latitude, Longitude FROM ulh WHERE [rank] = 1;
";
            using var conn = await _databaseConnectionFactory.CreateConnectionAsync();

            return await conn.QueryAsync<User, Location, User>(sql,
                (user, location) =>
                {
                    user.CurrentLocation = location;
                    return user;
                },
                splitOn: "Latitude");
        }

        public async Task UpdateUserLocationAsync(int userId, Location location)
        {
            const string sql = @"
INSERT INTO [dbo].[UserLocation]
           ([UserID]
           ,[Latitude]
           ,[Longitude])
     VALUES
           (@userId
           ,@latitude
           ,@longitude)
";

            using var conn = await _databaseConnectionFactory.CreateConnectionAsync();

            await conn.ExecuteAsync(sql, new { userId, latitude = location.Latitude, longitude = location.Longitude });
        }

        public async Task<User> GetLocationHistory(int userId)
        {
            const string sql = @"
     SELECT u.Id
          , u.[Name]
       FROM dbo.[User] u WITH(NOLOCK)
      WHERE u.Id = @userid;
     
     SELECT ul.Created
          ,	ul.Latitude
          , ul.Longitude
      FROM dbo.UserLocation ul WITH(NOLOCK)
     WHERE ul.UserId = @userid
 Order BY ul.Created DESC;
";

            using var conn = await _databaseConnectionFactory.CreateConnectionAsync();

            var results = await conn.QueryMultipleAsync(sql, new { userId });

            var user = await results.ReadFirstOrDefaultAsync<User>();
            var location = await results.ReadAsync<UserLocation>();

            if (user != null)
            {
                user.LocationHistory = new List<UserLocation>(location);
                return user;
            }

            return default;
        }

        public async Task<IEnumerable<User>> GetUsersWithInArea(Area requestArea)
        {
            const string sql = @"
WITH ulh AS
(
    SELECT u.Id
         , u.[Name]
         , ul.Latitude
         , ul.Longitude
         , RANK() OVER(PARTITION BY u.ID
                           ORDER BY ul.ID DESC) AS [rank]
      FROM dbo.[User] u WITH(NOLOCK)
INNER JOIN dbo.UserLocation ul WITH(NOLOCK)
        ON u.Id = ul.UserID
)
SELECT Id, [Name], Latitude, Longitude
  FROM ulh
 WHERE [rank] = 1
   AND Latitude between @minLatitude and @maxLatitude
   AND Longitude between @minLongitude and @maxLongitude;
";
            using var conn = await _databaseConnectionFactory.CreateConnectionAsync();

            return await conn.QueryAsync<User, Location, User>(sql,
                (user, location) =>
                {
                    user.CurrentLocation = location;
                    return user;
                },
                new
                {
                    minLatitude = requestArea.MinLocation.Latitude,
                    maxLatitude = requestArea.MaxLocation.Latitude,
                    minLongitude = requestArea.MinLocation.Longitude,
                    maxLongitude = requestArea.MaxLocation.Longitude
                },
                splitOn: "Latitude"
                );
        }
    }
}
