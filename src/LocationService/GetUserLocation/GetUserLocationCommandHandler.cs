using EnsureThat;
using MediatR;
using Repository.Code;
using Repository.Data;
using System.Threading;
using System.Threading.Tasks;

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
            EnsureArg.IsNotNull(request);

            return await _locationRepository.GetCurrentLocationAsync(request.UserId);
        }
    }
}