using LPCS.Server.Core.Web;
using LPCS.Server.Providers.DomainModels;
using LPCS.Server.RequestHandlers.Validators;

namespace LPCS.Server.RequestHandlers.ResourceModels
{
    public class PostProfilesRequest : BasePostRequest<ProfileModel, PostProfilesRequest, PostProfilesResponse, PostProfilesRequestValidator>
    {
     
    }
}
