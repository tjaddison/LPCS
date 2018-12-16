using LPCS.Server.Data.Mongo.Entities;
using Xenvya.Core.Data.Mongo;

namespace LPCS.Server.Data.Mongo.Repositories
{
    public class LocationLookupRepository : Repository<LocationLookup>
	{
		public LocationLookupRepository(string connectionString, string collection) : base(connectionString, collection) {}
	}
}
