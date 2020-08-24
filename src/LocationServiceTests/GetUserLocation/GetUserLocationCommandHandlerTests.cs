using LocationService.GetUserLocation;
using NSubstitute;
using Repository.Code;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LocationServiceTests.GetUserLocation
{
    public class GetUserLocationCommandHandlerTests
    {
        private readonly GetUserLocationCommandHandler _target;

        private readonly ILocationRepository _locationRepository;

        public GetUserLocationCommandHandlerTests()
        {
            this._locationRepository = Substitute.For<ILocationRepository>();

            this._target = new GetUserLocationCommandHandler(this._locationRepository);
        }

        [Fact]
        public async Task Handle_RequestIsNull_ThrowsArgumentNullException() =>
            await Assert.ThrowsAsync<ArgumentNullException>(() => this._target.Handle(null, CancellationToken.None));
    }
}