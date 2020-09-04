using EnsureThat;
using LocationService.Data;
using MediatR;
using Repository.Code;
using System.Threading;
using System.Threading.Tasks;
using Repository.Data;

namespace LocationService.Code.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ILocationRepository _locationRepository;

        public CreateUserCommandHandler(ILocationRepository locationRepository) =>
            this._locationRepository = locationRepository;

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNullOrEmpty(request.Name);

            return (await this._locationRepository.CreateUser(request.Name, request.Location.ToGeoJsonPoint(), request.Location.Recorded))
                .ToUser();
        }
    }
}