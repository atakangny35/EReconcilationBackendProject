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
   public class RemoveCacheAspect:methodInterceptors
    {
        public string pattern { get; set; }
        public ICacheManager  cacheManager { get; set; }
        public RemoveCacheAspect(string _pattern)
        {
            pattern = _pattern;
            cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();
        }

        protected override void Success(IInvocation invocation)
        {
            cacheManager.ReoveByPattern(pattern);
        }
    }
}
