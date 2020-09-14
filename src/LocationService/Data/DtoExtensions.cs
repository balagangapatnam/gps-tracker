using Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace LocationService.Data
{
    public static class DtoExtensions
    {
        public static User ToUser(this UserDto @this) =>
            new User
            {
                Id = @this.UserId,
                Name = @this.Name,
                LastKnownLocation = new Location(@this.LastKnownLocation.Coordinates.Latitude,
                    @this.LastKnownLocation.Coordinates.Longitude, @this.Recorded)
            };

        public static UserHistory ToUserHistory(this UserHistoryDto @this) =>
            new UserHistory
            {
                Id = @this.UserId,
                Name = @this.Name,
                LocationHistory = @this.LocationHistory
            };

        public static IEnumerable<User> ToUsers(this IEnumerable<UserDto> @this) =>
            @this.Select(ud => ud.ToUser());

        public static IEnumerable<UserHistory> ToUserHistories(this IEnumerable<UserHistoryDto> @this) =>
            @this.Select(uhd => uhd.ToUserHistory());
    }
}