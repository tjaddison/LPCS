using System.Threading.Tasks;
using LPCS.Server.Core.Data;
using LPCS.Server.Providers.DomainModels;

namespace LPCS.Server.Providers
{
    public interface ILogProvider
    {
        Task CreateLog(LogModel model);
        Task<PagedResult<LogModel>> GetLogs(int page, int size);
    }
}