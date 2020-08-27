using LocationService.Data;
using MediatR;
using System.Collections.Generic;

namespace LocationService.Code.GetAllUsersLocation
{
    public class GetAllUsersLocationCommand : IRequest<IEnumerable<User>> { }
}