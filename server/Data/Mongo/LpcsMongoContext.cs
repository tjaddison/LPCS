using LPCS.Server.Data.Mongo.Repositories;

namespace LPCS.Server.Data.Mongo 
{
    public class LpcsMongoContext 
    {
        public ProfileRepository Profiles { get; }
        public MessageRepository Message { get; }
        public LogRepository Logs { get; }

        public LpcsMongoContext(string connectionString)
        {
            Profiles = new ProfileRepository(connectionString, "Profiles");
            // Message = new MessageRepository(connectionString);
            // Logs = new LogRepository(connectionString);
        }
    }
}