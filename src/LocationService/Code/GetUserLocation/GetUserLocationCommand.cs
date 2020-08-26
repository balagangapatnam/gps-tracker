using LocationService.Data;
using MediatR;

namespace LocationService.Code.GetUserLocation
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