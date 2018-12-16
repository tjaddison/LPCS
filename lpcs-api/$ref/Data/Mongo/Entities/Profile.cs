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
        public string TitleType { get; set; }

        public Supervisor Supervisor { get; set; }
        public Settings Settings { get; set; }
        public Account Account { get; set; }
    }
}