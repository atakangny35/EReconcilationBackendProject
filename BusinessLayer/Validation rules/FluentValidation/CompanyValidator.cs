using BusinessLayer.Constance;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_rules.FluentValidation
{
   public class CompanyValidator:AbstractValidator<Companies>

    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Constances.CompanyNameNotEmpty);
            RuleFor(x => x.Address).NotEmpty().WithMessage(Constances.CompanyAdressNotEmpty);
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("Şirket adı minimum 4 karakter içermelidir.");
        }
    }
}
