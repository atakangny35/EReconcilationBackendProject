
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.interceptors
{
    public class methodInterceptors:MethotIterceptionBaseAttribute
    {
        protected virtual void Before (IInvocation invocation) { }
        protected virtual void After (IInvocation invocation) { }
        protected virtual void Exception (IInvocation invocation,Exception e) { }
        protected virtual void Success (IInvocation invocation) { }
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
