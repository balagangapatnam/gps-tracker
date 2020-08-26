using LocationService.Data;
using MediatR;
using Repository.Data;

namespace LocationService.Code.CreateUserCommand
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }

        public Location Location { get; set; }

        public CreateUserCommand(string name, Location location)
        {
            Name = name;
            Location = location;
        }
    }
}