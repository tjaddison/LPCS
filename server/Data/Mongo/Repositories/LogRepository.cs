using LPCS.Server.Data.Mongo.Entities;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Repositories
{
    public class LogRepository : Repository<Profile>
	{
		public LogRepository(string connectionString) : base(connectionString) {}
	}
}
