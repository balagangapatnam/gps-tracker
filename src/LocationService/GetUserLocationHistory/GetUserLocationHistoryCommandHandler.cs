using MediatR;
using Repository.Code;
using Repository.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService.GetUserLocationHistory
{
    public class GetUserLocationHistoryCommandHandler : IRequestHandler<GetUserLocationHistoryCommand, User>
    {
        private readonly ILocationRepository _locationRepository;

        public GetUserLocationHistoryCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<User> Handle(GetUserLocationHistoryCommand request, CancellationToken cancellationToken)
        {
            return await this._locationRepository.GetLocationHistory(request.UserId);
        }
    }
}