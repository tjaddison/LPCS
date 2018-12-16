using FluentValidation;
using LPCS.Server.RequestHandlers.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers.Validators
{
    public class PostLogsRequestValidator : AbstractValidator<PostLogsRequest>
    {
        public PostLogsRequestValidator()
        {
            // Check required attributes

            //RuleFor(request => request.Page).Must(BeANonNegativeInterger).WithMessage("Please specifiy a Page value greater than or equal to zero.");
            RuleFor(request => request.Body.EventType).NotEmpty().NotNull().WithMessage("EventType can not be null or empty.");
            RuleFor(request => request.Body.TimeTriggered).NotEmpty().NotNull().WithMessage("TimeTriggered can not be null or empty.");
            RuleFor(request => request.Body.TriggeredBy).NotEmpty().NotNull().WithMessage("TriggeredBy can not be null or empty.");
            //RuleFor(request => request.Body.EventType).NotEmpty().NotNull().WithMessage("EventType can not be null or empty.");

        }
    }
}
