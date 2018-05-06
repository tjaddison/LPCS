using LPCS.Server.Providers;
using LPCS.Server.RequestHandlers.ResourceModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers
{
    public class GetSingleProfileHandler : IRequestHandler<GetSingleProfileRequest, GetSingleProfileResponse>
    {
        private readonly IProfileProvider _profileProvider;

        public GetSingleProfileHandler(IProfileProvider ProfileProvider)
        {
            _profileProvider = ProfileProvider;
        }

        public Task<GetSingleProfileResponse> Handle(GetSingleProfileRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }

            var profile = _profileProvider.GetProfileById(request.ID);

            var response = new GetSingleProfileResponse
            {
                ID = request.ID,
                Result = profile
            };

            return Task.FromResult(response);
        }
    }
}
