using Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace LocationService.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location LastKnownLocation { get; set; }
    }

    public class UserHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Location> LocationHistory { get; set; }
    }

    public static class DtoExtensions
    {
        public static User ToUser(this UserDto @this)
        {
            return new User
            {
                Id = @this.UserId,
                Name = @this.Name,
                LastKnownLocation = new Location
                {
                    Latitude = @this.LastKnownLocation.Coordinates.Latitude,
                    Longitude = @this.LastKnownLocation.Coordinates.Longitude
                }
            };
        }

        public static UserHistory ToUserHistory(this UserHistoryDto @this)
        {
            return new UserHistory
            {
                Id = @this.UserId,
                Name = @this.Name,
                LocationHistory = @this.LocationHistory.Coordinates.Positions.Select(p => new Location
                {
                    Latitude = p.Latitude,
                    Longitude = p.Longitude
                })
            };
        }

        public static IEnumerable<User> ToUsers(this IEnumerable<UserDto> @this) =>
            @this.Select(ud => ud.ToUser());

        public static IEnumerable<UserHistory> ToUserHistories(this IEnumerable<UserHistoryDto> @this) =>
            @this.Select(uhd => uhd.ToUserHistory());
    }
}