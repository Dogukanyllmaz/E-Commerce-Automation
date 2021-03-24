using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SupplierValidator : AbstractValidator<Supplier>
    {

        public SupplierValidator()
        {
            RuleFor(s => s.ContactName).NotEmpty().MinimumLength(2);
            RuleFor(s => s.Address).NotEmpty();
            RuleFor(s => s.City).NotEmpty();
            RuleFor(s => s.PostalCode).NotEmpty();
            RuleFor(s => s.PhoneNumber).NotEmpty();
        }

    }
}
