using LocationService.Data;
using MediatR;
using Repository.Code;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService.Code.GetUserLocationHistory
{
    public class GetUserLocationHistoryCommandHandler : IRequestHandler<GetUserLocationHistoryCommand, UserHistory>
    {
        private readonly ILocationRepository _locationRepository;

        public GetUserLocationHistoryCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<UserHistory> Handle(GetUserLocationHistoryCommand request, CancellationToken cancellationToken) =>
            (await this._locationRepository.GetLocationHistory(request.UserId)).ToUserHistory();
    }
}