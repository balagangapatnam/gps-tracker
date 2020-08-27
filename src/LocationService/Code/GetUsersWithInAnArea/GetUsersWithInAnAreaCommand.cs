using LocationService.Data;
using MediatR;
using System.Collections.Generic;

namespace LocationService.Code.GetUsersWithInAnArea
{
    public class GetUsersWithInAnAreaCommand : IRequest<IEnumerable<User>>
    {
        public double[][] Area { get; set; }

        public GetUsersWithInAnAreaCommand(double[][] area) => Area = area;
    }
}