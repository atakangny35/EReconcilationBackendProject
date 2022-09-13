using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_rules.FluentValidation
{
   public class CurrencyAccountValidator:AbstractValidator<CurrencyAccount>
    {
        public CurrencyAccountValidator()
        {
            int minlength = 3;
            RuleFor(x => x.Name).NotEmpty().WithMessage("Firma adı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(minlength).WithMessage($"Firma adı minimum {minlength} karakter olmalıdır");
            RuleFor(x => x.Email).EmailAddress().WithMessage("EMail alanı mail cinsinden girilmelidir");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Firma adresi boş geçilemez");
            RuleFor(x => x.Address).MinimumLength(minlength).WithMessage($"Firma adresi minimum {minlength} karakter olmalıdır");
        }
    }
}
