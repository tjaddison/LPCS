using LPCS.Server.Data.Mongo.Entities;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Repositories
{
    public class LogRepository : Repository<Log>
	{
		public LogRepository(string connectionString, string collection) : base(connectionString, collection) {}
	}
}
