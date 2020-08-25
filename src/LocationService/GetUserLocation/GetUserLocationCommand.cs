using MediatR;
using Repository.Data;

namespace LocationService.GetUserLocation
{
    public class GetUserLocationCommand : IRequest<User>
    {
        public int UserId { get; }

        public GetUserLocationCommand(int userId)
        {
            this.UserId = userId;
        }
    }
}