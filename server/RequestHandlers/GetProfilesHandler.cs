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
    public class GetProfilesHandler : AsyncRequestHandler<GetProfilesRequest, GetProfilesResponse>
    {
        private readonly IProfileProvider _profileProvider;

        public GetProfilesHandler(IProfileProvider ProfileProvider)
        {
            _profileProvider = ProfileProvider;
        }

        protected async override Task<GetProfilesResponse> HandleCore(GetProfilesRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var profiles = await _profileProvider.GetProfiles(filter: request.F, page: request.Page, size: request.Size);

            var response = new GetProfilesResponse
            {
                Count = profiles.TotalCount,
                Result = profiles.Items
            };

            return response;
        }
    }

}
