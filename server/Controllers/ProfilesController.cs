using LPCS.Server.Core.Web;
using LPCS.Server.Providers.DomainModels;
using LPCS.Server.RequestHandlers.ResourceModels;
using LPCS.Server.RequestHandlers.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LPCS.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : BaseController
    {
        public ProfilesController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<IActionResult> Get(GetProfilesRequest request)
        {
            return await ProcessGetRequest<
                GetProfilesRequest, 
                GetProfilesResponse, 
                GetProfilesRequestValidator, 
                IEnumerable<ProfileListItemModel>>(request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(GetSingleProfileRequest request)
        {
            return await ProcessGetRequest<
                GetSingleProfileRequest,
                GetSingleProfileResponse,
                GetSingleProfileRequestValidator,
                ProfileModel>(request);
        }

        [HttpPost]
        public async Task Post([FromBody]PostProfilesRequest request)
        {
            await ProcessPostRequest<
                ProfileModel,
                PostProfilesRequest,
                PostProfilesResponse,
                PostProfilesRequestValidator>(request);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}