using LPCS.Server.Data.SqlServer.Repositories;
using LPCS.Server.Core.Data;

namespace LPCS.Server.Data.SqlServer
{
    public class MccUnitOfWork : IUnitOfWork
    {
        private readonly MccDatabaseContext _context;

        public MccUnitOfWork(MccDatabaseContext context)
        {
            _context = context;
            Lenders = new LenderRepository(_context);
        }

        public ILenderRepository Lenders { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
