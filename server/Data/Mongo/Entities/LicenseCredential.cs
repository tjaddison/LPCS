namespace LPCS.Server.Data.Mongo.Entities
{
    public class LicenseCredential
    {
        public string IssuedBy { get; set; }
        public string Identifier { get; set; }
        public int? Year { get; set; }
        public string Type { get; set; }
    }
}