using Castle.DynamicProxy;
using Core.Utilities.interceptors;
using Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Caching.Concrete
{
   public class CacheAspect: methodInterceptors
    {
        public int Duration { get; set; }
        public ICacheManager  cacheManager { get; set; }

        public CacheAspect(int duration = 60 )
        {
            Duration = duration;
            cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();
           // cacheManager = _cacheManager;
              
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            if (cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            cacheManager.add(key, invocation.ReturnValue, Duration);
        }
    }
}
