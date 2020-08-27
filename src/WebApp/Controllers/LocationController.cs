using LocationService.Code.CreateUserCommand;
using LocationService.Code.GetAllUsersLocation;
using LocationService.Code.GetUserLocation;
using LocationService.Code.GetUserLocationHistory;
using LocationService.Code.GetUsersWithInAnArea;
using LocationService.Code.PutUserLocation;
using LocationService.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("/users/location")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetLocationForAllUsers() =>
            this.Ok(await this._mediator.Send(new GetAllUsersLocationCommand()));

        [HttpGet("/users/{userId}/location")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetLocation(int userId) =>
            this.Ok(await this._mediator.Send(new GetUserLocationCommand(userId)));

        [HttpGet("/users/{userId}/location/history")]
        [ProducesResponseType(typeof(UserHistory), StatusCodes.Status200OK)]
        public async Task<ActionResult<UserHistory>> GetLocationHistory(int userId) =>
            this.Ok(await this._mediator.Send(new GetUserLocationHistoryCommand(userId)));

        [HttpPut("/users/{userId}/location")]
        public async Task Put(int userId, [FromBody] Location location) =>
            await this._mediator.Send(new PutUserLocationCommand(userId, location));

        [HttpPost("/users/location/area")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersWithInArea([FromBody] double[][] area) =>
            this.Ok(await this._mediator.Send(new GetUsersWithInAnAreaCommand(area)));

        [HttpPost("/users/{name}/location")]
        public async Task<ActionResult<User>> CreateUserRecord(string name, [FromBody] Location location) =>
            await this._mediator.Send(new CreateUserCommand(name, location));
    }
}
