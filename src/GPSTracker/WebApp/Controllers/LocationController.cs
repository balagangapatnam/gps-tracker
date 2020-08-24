using LocationService.Code;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IGetCurrentLocationForUsers _currentLocationForUsers;

        public LocationController(IGetCurrentLocationForUsers currentLocationForUsers)
        {
            _currentLocationForUsers = currentLocationForUsers;
        }

        [HttpGet("/users/{userId}/location/")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocation(int userId)
        {
            return Ok(await _currentLocationForUsers.GetUserWithCurrentLocation(userId));
        }

        [HttpGet("/users/{userId}/location/history")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocationHistory(int userId)
        {
            return Ok(await _currentLocationForUsers.GetUserWithLocationHistory(userId));
        }

        [HttpGet("/users/location/")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocationForAllUsers()
        {
            return Ok(await _currentLocationForUsers.GetUsersWithCurrentLocation());
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("location/{userId}/")]
        public void Put(int userId, [FromBody] Location location)
        {
            _currentLocationForUsers.UpdateLocation(userId, location);
        }
    }
}
