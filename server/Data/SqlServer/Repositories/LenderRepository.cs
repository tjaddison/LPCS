using LPCS.Server.Data.SqlServer.Entities;
using LPCS.Server.Core.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LPCS.Server.Data.SqlServer.Repositories
{
    public class LenderRepository : Repository<Lender>, ILenderRepository
    {
        private readonly MccDatabaseContext _context;

        public LenderRepository(MccDatabaseContext context)
            : base(context)
        {
            _context = context;
        }

        public Lender GetLenderByIdWithAddress(int id)
        {
            var result = _context.Lenders
                            .Include("Address")
                            .Include("Address.State")
                            .Where(l => l.LenderID == id)
                            .SingleOrDefault();

            return result;
                            
        }
    }
}
