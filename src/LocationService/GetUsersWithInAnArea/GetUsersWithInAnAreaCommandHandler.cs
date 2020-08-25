﻿using MediatR;
using Repository.Code;
using Repository.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LocationService.GetUsersWithInAnArea
{
    public class GetUsersWithInAnAreaCommandHandler : IRequestHandler<GetUsersWithInAnAreaCommand, IEnumerable<User>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetUsersWithInAnAreaCommandHandler(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersWithInAnAreaCommand request, CancellationToken cancellationToken)
        {
            return await this._locationRepository.GetUsersWithInArea(request.Area);
        }
    }
}