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
    public class GetProfileFilterHandler : AsyncRequestHandler<GetProfileFilterRequest, GetProfileFilterResponse>
    {
        private readonly IProfileProvider _profileProvider;

        public GetProfileFilterHandler(IProfileProvider ProfileProvider)
        {
            _profileProvider = ProfileProvider;
        }

        protected async override Task<GetProfileFilterResponse> HandleCore(GetProfileFilterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var filter = await _profileProvider.GetProfileFilter(filter: request.F, page: request.Pg, size: request.Sz);

            var response = new GetProfileFilterResponse
            {
                Result = filter
            };

            return response;
        }
    }

}
