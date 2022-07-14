using BusinessLayer.Constance;
using Core.entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation_rules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {   
        public UserValidator()
        {   
            int usernamelength = 4;
            RuleFor(x => x.Email).EmailAddress().WithMessage(Constances.MustBeEmail);
            RuleFor(x => x.Name).NotEmpty().WithMessage(Constances.NameMust);
            RuleFor(x => x.Email).NotEmpty().WithMessage(Constances.MailMust);
            RuleFor(x => x.Name).MinimumLength(usernamelength).WithMessage($"Kullaıcı adı minimum {usernamelength} karaketer olmalıdır!");
            
        }
    }
}
