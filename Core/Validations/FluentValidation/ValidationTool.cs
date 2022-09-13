using Core.Aspect.Validation;
using Core.Utilities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(object entity, IValidator validator)
        {
            var validationContext = new ValidationContext<object>(entity);
             var validationResult = validator.Validate(validationContext);
            
            if (!validationResult.IsValid)
            {
               // return validationResult;
                throw new ValidationException(validationResult.Errors);
                //throw new registerexception("test");
            }
            

        }
  
    }


}

