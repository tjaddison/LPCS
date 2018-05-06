using LPCS.Server.Data.SqlServer.Entities;
using LPCS.Server.Core.Data;

namespace LPCS.Server.Data.SqlServer.Repositories
{
    public interface ILenderRepository : IRepository<Lender>
    {
        Lender GetLenderByIdWithAddress(int id);
    }
}
