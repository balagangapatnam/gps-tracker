using MediatR;
using Repository.Data;

namespace LocationService.GetUserLocationHistory
{
    public class GetUserLocationHistoryCommand : IRequest<User>
    {
        public int UserId { get; set; }

        public GetUserLocationHistoryCommand(int userId)
        {
            UserId = userId;
        }
    }
}