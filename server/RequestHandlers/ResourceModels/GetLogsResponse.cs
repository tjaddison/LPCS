using LPCS.Server.Core.Web;
using LPCS.Server.Providers.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers.ResourceModels
{
    public class GetLogsResponse : BaseResponse<IEnumerable<LogModel>>
    {
        public long Count { get; set; }
    }

    
}
