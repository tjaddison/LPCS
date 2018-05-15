using LPCS.Server.Providers;
using LPCS.Server.RequestHandlers.ResourceModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers
{
    public class PostLogsHandler : AsyncRequestHandler<PostLogsRequest, PostLogsResponse>
    {
        private readonly ILogProvider _LogProvider;

        public PostLogsHandler(ILogProvider LogProvider)
        {
            _LogProvider = LogProvider;
        }

        protected async override Task<PostLogsResponse> HandleCore(PostLogsRequest request)
        {
            await _LogProvider.CreateLog(request.Body);

            var response = new PostLogsResponse
            { 
            };

            return response;
        }
    }
}
