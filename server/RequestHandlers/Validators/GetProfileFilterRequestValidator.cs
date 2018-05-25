using LPCS.Server.RequestHandlers.ResourceModels;
using FluentValidation;

namespace LPCS.Server.RequestHandlers.Validators
{
    public class GetProfileFilterRequestValidator : AbstractValidator<GetProfileFilterRequest>
    {
        public GetProfileFilterRequestValidator()
        {
            RuleFor(request => request.Pg).Must(BeANonNegativeInterger).WithMessage("Please specifiy a Page value greater than or equal to zero.");
            RuleFor(request => request.Sz).Must(BeANonNegativeInterger).WithMessage("Please specifiy a Size value greater than or equal to zero.");
        }

        private bool BeANonNegativeInterger(int number)
        {
            return number >= 0;
        }
    }
 
}
