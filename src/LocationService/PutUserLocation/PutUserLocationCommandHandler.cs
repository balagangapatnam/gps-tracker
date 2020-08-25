using MediatR;
using Repository.Code;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService.PutUserLocation
{
    public class PutUserLocationCommandHandler : AsyncRequestHandler<PutUserLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;

        public PutUserLocationCommandHandler(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        protected override async Task Handle(PutUserLocationCommand request, CancellationToken cancellationToken)
        {
            await this._locationRepository.UpdateUserLocationAsync(request.UserId, request.Location);
        }
    }
}