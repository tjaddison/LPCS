using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;

namespace LPCS.Server.Core.Web
{
    public class BaseGetRequest<TRequest, TResponse, TValidator> : IRequest<TResponse>
        where TValidator : AbstractValidator<TRequest>, new()
        where TRequest : class
    {
        #region For Validation

        private ValidationResult _validationResults;
        private TValidator _validator;
        
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

        #region For Pagination

        public int Pg { get; set; } = 0; // Page
        public int Sz { get; set; } = 10; // Size
        public IEnumerable<OrderItem> Odrs { get; set; } // Orders

        public abstract class OrderItem
        {
            public string By { get; set; } // By
            public string Dr { get; set; } // Direction
        }

        #endregion

    }


}
