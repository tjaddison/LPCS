using LPCS.Server.RequestHandlers.ResourceModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LPCS.Server.Providers;

namespace LPCS.Server.RequestHandlers
{
    public class GetLogsHandler : AsyncRequestHandler<GetLogsRequest, GetLogsResponse>
    {
        private readonly ILogProvider _LogProvider;

        public GetLogsHandler(ILogProvider LogProvider)
        {
            _LogProvider = LogProvider;
        }

        protected async override Task<GetLogsResponse> HandleCore(GetLogsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var Logs = await _LogProvider.GetLogs(page: request.Pg, size: request.Sz);

            var response = new GetLogsResponse
            {
                Count = Logs.TotalCount,
                Result = Logs.Items
            };

            return response;
        }
    }

}
