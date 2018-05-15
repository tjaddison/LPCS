using LPCS.Server.RequestHandlers.ResourceModels;
using FluentValidation;

namespace LPCS.Server.RequestHandlers.Validators
{
    public class GetLogsRequestValidator : AbstractValidator<GetLogsRequest>
    {
        public GetLogsRequestValidator()
        {
            RuleFor(request => request.Page).Must(BeANonNegativeInterger).WithMessage("Please specifiy a Page value greater than or equal to zero.");
            RuleFor(request => request.Size).Must(BeANonNegativeInterger).WithMessage("Please specifiy a Size value greater than or equal to zero.");
        }

        private bool BeANonNegativeInterger(int number)
        {
            return number >= 0;
        }
    }
 
}
