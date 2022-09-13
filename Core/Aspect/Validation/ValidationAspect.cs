
using Castle.DynamicProxy;
using Core.entities.Concrete;
using Core.Utilities.Concrete;
using Core.Utilities.interceptors;
using Core.Validations.FluentValidation;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Validation
{
    public class ValidationAspect: methodInterceptors
    {
        public Type validationType { get; set; }

        public ValidationAspect(Type _validationType)
        {
            validationType = _validationType;
            if (!typeof(IValidator).IsAssignableFrom(validationType))
            {
                throw new System.Exception("Validasyon Tip Hatası");
            }
            
           
        }
        protected override void Before(IInvocation invocation)
        {
            List<string> strings = new List<string>();
            ValidationResult validationResult= new ValidationResult();
            var validattor = (IValidator)Activator.CreateInstance(validationType);
            var entityType = validationType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(entity, validattor);
            }
            
            
        }
    }
    
}

