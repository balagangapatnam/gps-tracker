using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.GeoJsonObjectModel;

namespace LocationService.Data
{
    public class Area
    {
        public List<Location> Locations { get; set; }
    }

    public static class AreaExtenisons
    {
        public static GeoJsonPolygon<GeoJson2DGeographicCoordinates> ToGeoJsonPolygon(this Area area)
        {
            return new GeoJsonPolygon<GeoJson2DGeographicCoordinates>(
                new GeoJsonPolygonCoordinates<GeoJson2DGeographicCoordinates>(
                    new GeoJsonLinearRingCoordinates<GeoJson2DGeographicCoordinates>(area.Locations.Select(location =>
                        new GeoJson2DGeographicCoordinates(location.Longitude, location.Latitude)).ToList())));
        }
    }
}