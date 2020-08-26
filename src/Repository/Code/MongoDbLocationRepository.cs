using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Code
{
    public class MongoDbLocationRepository : ILocationRepository
    {
        private readonly IMongoCollection<UserDto> _currentLocations;
        private readonly IMongoCollection<UserHistoryDto> _historicalLocations;

        public MongoDbLocationRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Database);

            this._currentLocations = database.GetCollection<UserDto>(databaseSettings.CurrentLocationsCollection);
            this._historicalLocations = database.GetCollection<UserHistoryDto>(databaseSettings.HistoricalLocationsCollection);
        }

        public async Task<IEnumerable<UserDto>> GetCurrentLocationForAllUsersAsync() =>
            await (await this._currentLocations.FindAsync<UserDto>(FilterDefinition<UserDto>.Empty)).ToListAsync();

        public async Task<UserDto> GetCurrentLocationAsync(int userId) =>
            await (await this._currentLocations.FindAsync(u => u.UserId == userId)).FirstOrDefaultAsync();

        public async Task UpdateorAddUserLocationAsync(int userId, GeoJsonPoint<GeoJson2DGeographicCoordinates> location)
        {
            await this._currentLocations.FindOneAndUpdateAsync(u => u.UserId == userId,
                Builders<UserDto>.Update.Set("location", location));

            await this._historicalLocations.FindOneAndUpdateAsync(u => u.UserId == userId,
                Builders<UserHistoryDto>.Update.Push("location.coordinates", location.Coordinates));
        }

        public async Task<UserHistoryDto> GetLocationHistory(int userId) =>
            await (await this._historicalLocations.FindAsync(u => u.UserId == userId)).FirstOrDefaultAsync();

        public async Task<IEnumerable<UserDto>> GetUsersWithInArea(GeoJsonPolygon<GeoJson2DGeographicCoordinates> area) =>
            await (await this._currentLocations.FindAsync(
                Builders<UserDto>.Filter.GeoWithin(u => u.LastKnownLocation, area))).ToListAsync();

        //public async Task<User> CreateUser(string name, Location location)
        //{
        //    var userId = (int)await this._currentLocations.CountDocumentsAsync(FilterDefinition<User>.Empty) + 1;

        //    var user = new User
        //    {
        //        UserId = userId,
        //        Name = name,
        //        LastKnownLocation = location.ToGeoJsonPoint()
        //    };

        //    await this._currentLocations.InsertOneAsync(user);

        //    await this._historicalLocations.InsertOneAsync(new UserHistory
        //    {
        //        UserId = userId,
        //        Name = name,
        //        LocationHistory = location.ToGeoJsonMultiPoint()

        //    });

        //    return user;
        //}
    }
}