using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.Core.Data
{
    /// <summary>
    ///  should also contain a collection of repositories
    /// </summary>
    /// <returns></returns>
    public interface IUnitOfWork : IDisposable
    {

        int Complete();
    }
}
