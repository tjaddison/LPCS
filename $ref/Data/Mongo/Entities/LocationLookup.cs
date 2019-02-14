using MongoDB.Driver.GeoJsonObjectModel;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Entities 
{
    public class LocationLookup : Entity
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string County { get; set; }
        public GeoJson Location { get; set; }
    }
    public class GeoJson
    {
        public string Type { get; set; }
        public double[] Coordinates { get; set; }     
    }
    
}