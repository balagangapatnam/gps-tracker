using Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationService.Code
{
    public interface IGetCurrentLocationForUsers
    {
        Task<IEnumerable<User>> GetUsersWithCurrentLocation();

        Task<User> GetUserWithCurrentLocation(int userId);

        Task UpdateLocation(int userId, Location location);

        Task<User> GetUserWithLocationHistory(int userId);
    }
}