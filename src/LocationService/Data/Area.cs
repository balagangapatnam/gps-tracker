using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace LocationService.Data
{
    public class Area
    {
        public List<Location> Locations { get; set; }
    }

    public static class AreaExtenisons
    {
        public static GeoJsonPolygon<GeoJson2DGeographicCoordinates> ToGeoJsonPolygon(this double[][] area) =>
            new GeoJsonPolygon<GeoJson2DGeographicCoordinates>(
                new GeoJsonPolygonCoordinates<GeoJson2DGeographicCoordinates>(
                    new GeoJsonLinearRingCoordinates<GeoJson2DGeographicCoordinates>(area.Select(coordinates =>
                        new GeoJson2DGeographicCoordinates(coordinates[1], coordinates[0])).ToList())));
    }
}