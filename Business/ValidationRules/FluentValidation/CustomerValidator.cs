using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(c => c.ContactName).NotEmpty().MinimumLength(2);
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Country).NotEmpty();
            RuleFor(c => c.PostalCode).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
        }

    }
}
