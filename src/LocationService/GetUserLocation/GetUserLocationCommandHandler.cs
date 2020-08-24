using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository.Code;
using Repository.Data;

namespace LocationService.GetUserLocation
{
    public class GetUserLocationCommandHandler : IRequestHandler<GetUserLocationCommand, User>
    {
        private readonly ILocationRepository _locationRepository;

        public GetUserLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<User> Handle(GetUserLocationCommand request, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetCurrentLocationAsync(request.UserId);
        }
    }
}