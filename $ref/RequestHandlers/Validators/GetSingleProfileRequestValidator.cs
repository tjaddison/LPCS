using LPCS.Server.RequestHandlers.ResourceModels;
using FluentValidation;

namespace LPCS.Server.RequestHandlers.Validators
{
    public class GetSingleProfileRequestValidator : AbstractValidator<GetSingleProfileRequest>
    {
        public GetSingleProfileRequestValidator()
        {
            //RuleFor(request => request.ID).Must(BeANonNegativeInterger).WithMessage("Please specifiy a valid ID.");
        }

        // private bool BeANonNegativeInterger(int number)
        // {
        //     return number >= 0;
        // }
    }
}
