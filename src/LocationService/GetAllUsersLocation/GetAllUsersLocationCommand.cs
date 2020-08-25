using MediatR;
using Repository.Data;
using System.Collections.Generic;

namespace LocationService.GetAllUsersLocation
{
    public class GetAllUsersLocationCommand : IRequest<IEnumerable<User>> { }
}