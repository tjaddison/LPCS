using System;

namespace LPCS.Server.Providers.DomainModels
{
    public class ProfileListItemModel
    {
        public string ID { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
    }
}
