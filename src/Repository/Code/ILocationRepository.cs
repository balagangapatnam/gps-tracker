using MongoDB.Driver.GeoJsonObjectModel;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Code
{
    public interface ILocationRepository
    {
        Task<IEnumerable<UserDto>> GetCurrentLocationForAllUsersAsync();

        Task<UserDto> GetCurrentLocationAsync(int userId);

        Task UpdateorAddUserLocationAsync(int userId, GeoJsonPoint<GeoJson2DGeographicCoordinates> location, DateTime recorded);

        Task<UserHistoryDto> GetLocationHistory(int userId);

        Task<IEnumerable<UserDto>> GetUsersWithInArea(GeoJsonPolygon<GeoJson2DGeographicCoordinates> area);

        Task<UserDto> CreateUser(string name, GeoJsonPoint<GeoJson2DGeographicCoordinates> location, DateTime recorded);
    }
}