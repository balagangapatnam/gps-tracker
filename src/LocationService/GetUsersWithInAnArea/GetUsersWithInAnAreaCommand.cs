using MediatR;
using Repository.Data;
using System.Collections.Generic;

namespace LocationService.GetUsersWithInAnArea
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