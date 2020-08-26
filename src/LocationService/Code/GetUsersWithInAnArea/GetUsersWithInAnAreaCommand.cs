using LocationService.Data;
using MediatR;
using System.Collections.Generic;

namespace LocationService.Code.GetUsersWithInAnArea
{
    public class GetUsersWithInAnAreaCommand : IRequest<IEnumerable<User>>
    {
        public Area Area { get; set; }

        public GetUsersWithInAnAreaCommand(Area area) => Area = area;
    }
}