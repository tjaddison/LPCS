using LPCS.Server.Providers;
using LPCS.Server.RequestHandlers.ResourceModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers
{
    public class PostProfilesHandler : AsyncRequestHandler<PostProfilesRequest, PostProfilesResponse>
    {
        private readonly IProfileProvider _ProfileProvider;

        public PostProfilesHandler(IProfileProvider ProfileProvider)
        {
            _ProfileProvider = ProfileProvider;
        }

        protected async override Task<PostProfilesResponse> HandleCore(PostProfilesRequest request)
        {
            await _ProfileProvider.CreateProfile(request.Body);

            var response = new PostProfilesResponse
            { 
            };

            return response;
        }
    }
}
