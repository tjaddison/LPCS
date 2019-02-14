namespace LPCS.Server.Providers.DomainModels
{
    public class ProfileListFilterModel
    {
        public string ke { get; set; }
        public string soBy { get; set; }
        public int? mfd { get; set; } = 20;
        public string mfz { get; set; }
        public string[] agSp { get; set; }
        public string[] et { get; set; }
        public string[] ev { get; set; }
        public string[] la { get; set; }
        public string[] mo { get; set; }
        public string[] re { get; set; }
        public string[] spIn { get; set; }
        public string[] sp { get; set; }
        public string[] tr { get; set; }        
    }
}