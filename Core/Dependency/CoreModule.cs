using Core.Aspect.Caching;
using Core.Aspect.Caching.Concrete;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dependency
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, McCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
