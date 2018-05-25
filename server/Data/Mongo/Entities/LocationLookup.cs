using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Entities 
{
    public class LocationLookup : Entity
    {
        public string zip { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}