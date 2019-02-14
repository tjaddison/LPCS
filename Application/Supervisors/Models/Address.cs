namespace LPCS.Server.Data.Mongo.Entities
{
    public class Address
    {
        public bool IsPrivate { get; set; }  
        public bool IsPrimary { get; set; }  // TODO: deprecate
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Type { get; set; }        
         public Location Location  { get; set; }
    }

    public class Location
    {
        public double X { get; set; }  // Longitude
        public double Y { get; set; }  // Latitude
    }
}