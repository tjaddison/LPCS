using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LPCS.Server.Core.Web
{
    public class BaseController : Controller
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> ProcessGetRequest<TRequest, TResponse, TValidator, TReturnType>(BaseGetRequest<TRequest, TResponse, TValidator> request)
            where TRequest : class
            where TResponse : BaseResponse<TReturnType>
            where TValidator : AbstractValidator<TRequest>, new()
        {
            if (!request.IsValid)
            {
                return BadRequest(request.Errors);
            }

            var result = await _mediator.Send(request);

            if (!ResultsExist(result.Result))
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool ResultsExist<TReturnType>(TReturnType results)
        {
            if (results == null) return false;

            System.Collections.ICollection collection = results as System.Collections.ICollection;

            if (collection != null)
            {
                if (collection.Count == 0) return false;
            }

            return true;
        }

        public async Task<IActionResult> ProcessPostRequest<TBody, TRequest, TResponse, TValidator>(BasePostRequest<TBody, TRequest, TResponse, TValidator> request)
            where TRequest : class
            where TValidator : AbstractValidator<TRequest>, new()
        {
            if (!request.IsValid)
            {
                return BadRequest(request.Errors);
            }

            await _mediator.Send(request);

            return Created("", request.Body);
        }
    }
}
