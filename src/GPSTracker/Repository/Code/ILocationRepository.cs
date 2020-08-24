using Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Code
{
    public interface ILocationRepository
    {
        Task<IEnumerable<User>> GetCurrentLocationForAllUsersAsync();

        Task<User> GetCurrentLocationAsync(int userId);

        Task UpdateUserLocationAsync(int userId, Location location);

        Task<User> GetLocationHistory(int userId);
    }
}