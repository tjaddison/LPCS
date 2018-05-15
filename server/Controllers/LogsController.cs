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
    public class LogsController : BaseController
    {
        public LogsController(IMediator mediator) : base(mediator) {}

        [HttpGet]
        public async Task<IActionResult> Get(GetLogsRequest request)
        {
            return await ProcessGetRequest<
                GetLogsRequest, 
                GetLogsResponse, 
                GetLogsRequestValidator, 
                IEnumerable<LogModel>>(request);
        }

        [HttpPost]
        public async Task Post([FromBody]PostLogsRequest request)
        {
            await ProcessPostRequest<
                LogModel,
                PostLogsRequest,
                PostLogsResponse,
                PostLogsRequestValidator>(request);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}