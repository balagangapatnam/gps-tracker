using Repository.Code;
using Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationService.Code
{
    public class CurrentLocationRetriever : IGetCurrentLocationForUsers
    {
        private readonly ILocationRepository _locationRepository;

        public CurrentLocationRetriever(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<User>> GetUsersWithCurrentLocation()
        {
            return await _locationRepository.GetCurrentLocationForAllUsersAsync();

        }

        public async Task<User> GetUserWithCurrentLocation(int userId)
        {
            return await _locationRepository.GetCurrentLocationAsync(userId);
        }

        public async Task UpdateLocation(int userId, Location location)
        {
            await _locationRepository.UpdateUserLocationAsync(userId, location);
        }

        public async Task<User> GetUserWithLocationHistory(int userId)
        {
            return await _locationRepository.GetLocationHistory(userId);
        }
    }
}