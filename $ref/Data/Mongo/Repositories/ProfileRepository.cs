using LPCS.Server.Data.Mongo.Entities;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Repositories
{
    public class ProfileRepository : Repository<Profile>
	{
		public ProfileRepository(string connectionString, string collection) : base(connectionString, collection) {}
	}
}
