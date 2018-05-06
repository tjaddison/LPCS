namespace LPCS.Server.Data.Mongo.Entities
{
    public class Address
    {
        public bool IsPrivate { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Type { get; set; }
    }
}