using LPCS.Server.Data.Mongo.Entities;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Repositories
{
    public class MessageRepository : Repository<Profile>
	{
		public MessageRepository(string connectionString) : base(connectionString) {}
	}
}
