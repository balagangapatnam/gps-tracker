using LocationService.GetAllUsersLocation;
using LocationService.GetUserLocation;
using LocationService.GetUserLocationHistory;
using LocationService.PutUserLocation;
using MediatR;
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
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator) => _mediator = mediator;

        [HttpGet("/users/location/")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocationForAllUsers() =>
            this.Ok(await this._mediator.Send(new GetAllUsersLocationCommand()));

        [HttpGet("/users/{userId}/location/")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocation(int userId) =>
            this.Ok(await this._mediator.Send(new GetUserLocationCommand(userId)));

        [HttpGet("/users/{userId}/location/history")]
        public async Task<ActionResult<IEnumerable<string>>> GetLocationHistory(int userId) =>
            this.Ok(await this._mediator.Send(new GetUserLocationHistoryCommand(userId)));

        //[HttpGet("/users/location/area")]
        //public async Task<ActionResult<IEnumerable<string>>> GetUsersWithInArea([FromBody] Area area)
        //{
        //    return Ok(await _currentLocationForUsers.GetUsersWithCurrentLocation());
        //}

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPut("location/{userId}/")]
        public async Task Put(int userId, [FromBody] Location location) =>
            await this._mediator.Send(new PutUserLocationCommand(userId, location));
    }
}
