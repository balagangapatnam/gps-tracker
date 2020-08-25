using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Repository.Code;
using Repository.Data;

namespace LocationService.GetAllUsersLocation
{
    public class GetAllUsersLocationCommandHandler : IRequestHandler<GetAllUsersLocationCommand, IEnumerable<User>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllUsersLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersLocationCommand request, CancellationToken cancellationToken)
        {
            return await this._locationRepository.GetCurrentLocationForAllUsersAsync();
        }
    }
}