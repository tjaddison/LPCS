using FluentValidation;
using LPCS.Server.RequestHandlers.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPCS.Server.RequestHandlers.Validators
{
    public class PostProfilesRequestValidator : AbstractValidator<PostProfilesRequest>
    {
        public PostProfilesRequestValidator()
        {
            // Check required attributes

            //RuleFor(request => request.Page).Must(BeANonNegativeInterger).WithMessage("Please specifiy a Page value greater than or equal to zero.");

        }
    }
}
