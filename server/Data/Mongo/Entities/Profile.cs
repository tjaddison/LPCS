using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Entities 
{
    public class Profile : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { get; set; }
        public bool? SendHtmlEmail { get; set; }
        public string TitleType { get; set; }
        public Supervisor Supervisor { get; set; }
    }
}