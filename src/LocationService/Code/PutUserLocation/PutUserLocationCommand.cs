using LocationService.Data;
using MediatR;
using Repository.Data;

namespace LocationService.Code.PutUserLocation
{
    public class PutUserLocationCommand : IRequest
    {
        public int UserId { get; set; }
        public Location Location { get; set; }

        public PutUserLocationCommand(int userId, Location location)
        {
            UserId = userId;
            Location = location;
        }
    }
}