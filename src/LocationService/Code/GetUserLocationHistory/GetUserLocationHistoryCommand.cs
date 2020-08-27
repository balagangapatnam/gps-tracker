using LocationService.Data;
using MediatR;

namespace LocationService.Code.GetUserLocationHistory
{
    public class GetUserLocationHistoryCommand : IRequest<UserHistory>
    {
        public int UserId { get; set; }

        public GetUserLocationHistoryCommand(int userId) => UserId = userId;
    }
}