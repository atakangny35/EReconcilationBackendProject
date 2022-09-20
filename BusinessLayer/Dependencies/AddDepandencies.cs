using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Core.Utilities.Security.JWT;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.interceptors;
using Core.Aspect.Caching.Concrete;
using Core.Aspect.Caching;

namespace BusinessLayer.Dependencies
{
    public class AutoFacBusinnessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyRepository>().As<ICompanyDal>();



            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<EfMailRepository>().As<IMailDal>();
            builder.RegisterType<MailManager>().As<IMailService>();

            builder.RegisterType<MailManager>().As<IMailService>();
            builder.RegisterType<EfMailRepository>().As<IMailDal>();

            builder.RegisterType<EfMailParameterRepository>().As<IMailParameterDal>();
            builder.RegisterType<MailParameterManager>().As<IMailParameterService>();

            builder.RegisterType<EfMailPatternRepository>().As<IMailPatternDal>();
            builder.RegisterType<MailPatternManger>().As<IMailPatternService>();

            builder.RegisterType<EfUserCompanyRepository>().As<IUserCompanyDal>();
            builder.RegisterType<EfCompanyRepository>().As<ICompanyDal>();

            builder.RegisterType<EfUserRepository>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<EfCurrencyAccountRepository>().As<ICurrencyAccountDal>();
            builder.RegisterType<CurrencyAccountManager>().As<ICurrencyAccountService>();

            builder.RegisterType<EfAccountReconcillationRepository>().As<IAccountReconcillationDal>();
            builder.RegisterType<AccountReconcillationManager>().As<IAccountReconcillationService>();

            builder.RegisterType<EfAccountReconcillationsDetailRepository>().As<IAccountReconcillationsDetailDal>();
            builder.RegisterType<AccountReconcillationsDetailManager>().As<IAccountReconcillationsDetailService>();

            builder.RegisterType<BabsReconcilationManager>().As<IBabsReconcilationService>();
            builder.RegisterType<EfBabsReconcilationRepository>().As<IBabsReconcilationDal>();

            builder.RegisterType<BabsReconcilationDetailManager>().As<IBabsReconcilationDetailService>();
            builder.RegisterType<EfBabsReconcilationDetailRepository>().As<IBabsReconcilationDetailDal>();

            builder.RegisterType<EfOperationClaimRepository>().As<IOperationClaimDal>();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();

            builder.RegisterType<EFUserOperatainClaimRepository>().As<IUserOperationClaimDal>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<EfRegisterTermsRepository>().As<IRegisterTermsDal>();
            builder.RegisterType<IRegisterTermsManager>().As<IRegisterTermsService>();

            builder.RegisterType<EFUserOperatainClaimRepository>().As<IUserOperationClaimDal>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<McCacheManager>().As<ICacheManager>();

            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
               new Castle.DynamicProxy.ProxyGenerationOptions()
               {
                   Selector = new AspectInterceptorSelector()
               }

                ).SingleInstance();
        }
    }
    /*
    public static class AddDepandencies
    {
        public static void CostumDepandency(this IServiceCollection services)
        {
            services.AddScoped<ICompanyDal,EfCompanyRepository>();
            services.AddScoped<ICompanyService, CompanyManager>();

            services.AddScoped<ICurrencyDal, EfCurrencyRepository>();
            services.AddScoped<ICurrencyService, CurrencyManager>();

            services.AddScoped<IAccountReconcillationsDetailDal, EfAccountReconcillationsDetailRepository>();
            services.AddScoped<IAccountReconcillationsDetailService, AccountReconcillationsDetailManager>();

            services.AddScoped<IAccountReconcillationDal, EfAccountReconcillationRepository>();
            services.AddScoped<IAccountReconcillationService, AccountReconcillationManager>();

            services.AddScoped<IBabsReconcilationDal, EfBabsReconcilationRepository>();
            services.AddScoped<IBabsReconcilationService, BabsReconcilationManager>();

            services.AddScoped<IBabsReconcilationDetailDal, EfBabsReconcilationDetailRepository>();
            services.AddScoped<IBabsReconcilationDetailService, BabsReconcilationDetailManager>();

            services.AddScoped<ICurrencyAccountDal, EfCurrencyAccountRepository>();
            services.AddScoped<ICurrencyAccountService, CurrencyAccountManager>();

            services.AddScoped<IMailParameterDal, EfMailParameterRepository>();
            services.AddScoped<IMailParameterService, MailParameterManager>();

            services.AddScoped<IUserCompanyDal, EfUserCompanyRepository>();



            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserRepository>();

            services.AddScoped<IAuthService, AuthManager>();

            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddScoped<IMailService, MailManager>();
            services.AddScoped<IMailDal, EfMailRepository>();

            services.AddScoped<IMailPatternDal, EfMailPatternRepository>();

            services.AddScoped<IMailPatternService, MailPatternManger>();



             






        }
    }*/
}
