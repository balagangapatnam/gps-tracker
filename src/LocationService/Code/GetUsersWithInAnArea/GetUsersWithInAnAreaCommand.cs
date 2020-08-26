using System.Collections.Generic;
using LocationService.Data;
using MediatR;
using Repository.Data;

namespace LocationService.Code.GetUsersWithInAnArea
{
    public class GetUsersWithInAnAreaCommand : IRequest<IEnumerable<User>>
    {
        public Area Area { get; set; }

        public GetUsersWithInAnAreaCommand(Area area)
        {
            Area = area;
        }
    }
}