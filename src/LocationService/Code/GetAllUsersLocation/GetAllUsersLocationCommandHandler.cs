using LocationService.Data;
using MediatR;
using Repository.Code;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService.Code.GetAllUsersLocation
{
    public class GetAllUsersLocationCommandHandler : IRequestHandler<GetAllUsersLocationCommand, IEnumerable<User>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllUsersLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersLocationCommand request, CancellationToken cancellationToken) =>
            (await this._locationRepository.GetCurrentLocationForAllUsersAsync()).ToUsers();
    }
}