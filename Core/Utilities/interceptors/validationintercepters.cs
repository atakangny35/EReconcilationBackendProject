using Castle.DynamicProxy;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.interceptors
{
    public class validationintercepters: MethotIterceptionBaseAttribute
    {
        protected virtual ErrorResult Before(IInvocation invocation) { return new ErrorResult(" "); }

        protected virtual void After(IInvocation invocation) { }
        protected virtual void Exception(IInvocation invocation, Exception e) { }
        protected virtual void Success(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var IsSuccess = true;
            Before(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                IsSuccess = false;
                Exception(invocation, e);
                throw;

            }
            finally
            {
                if (IsSuccess == true)
                {
                    Success(invocation);
                }
            }
            After(invocation);

        }
    }
}
