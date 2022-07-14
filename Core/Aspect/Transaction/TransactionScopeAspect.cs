using Castle.DynamicProxy;
using Core.Utilities.interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspect.Transaction
{
  public class TransactionScopeAspect:methodInterceptors
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope =new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();
                    throw;
                    
                }
            }
        }
    }
}
