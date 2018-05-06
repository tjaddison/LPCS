using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;

namespace LPCS.Server.Core.Web
{
    public class BasePostRequest<TBody, TRequest, TResponse, TValidator> : IRequest<TResponse>
        where TValidator : AbstractValidator<TRequest>, new()
        where TRequest : class
    {
        #region For Validation

        private ValidationResult _validationResults;
        private TValidator _validator;

        public TBody Body { get; set; }

        public bool IsValid
        {
            get
            {
                Initialize();
                return _validationResults.IsValid;
            }
        }

        public IList<ValidationFailure> Errors
        {
            get
            {
                Initialize();
                return _validationResults.Errors;
            }
        }

        private void Initialize()
        {
            if (_validator == null)
            {
                _validator = new TValidator();
            }

            _validationResults = _validator.Validate(this as TRequest);

        }

        #endregion


    }


}
