using EnsureThat;
using LocationService.Data;
using MediatR;
using Repository.Code;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService.Code.GetUserLocation
{
    public class GetUserLocationCommandHandler : IRequestHandler<GetUserLocationCommand, User>
    {
        private readonly ILocationRepository _locationRepository;

        public GetUserLocationCommandHandler(ILocationRepository locationRepository) =>
            _locationRepository = locationRepository;

        public async Task<User> Handle(GetUserLocationCommand request, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(request);

            return (await _locationRepository.GetCurrentLocationAsync(request.UserId)).ToUser();
        }
    }
}