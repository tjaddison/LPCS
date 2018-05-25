using System;

namespace LPCS.Server.Providers.DomainModels
{
    public class ProfileListItemModel
    {
        public string ID { get; set; }     
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Blurb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
