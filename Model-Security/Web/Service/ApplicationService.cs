using AutoMapper;
using Business.Implementations.Model_Security;
using Business.Interfaces;
using Business.Interfaces.Model_Security;
using Data.Interfaces.DataBasic;
using Data.Interfaces.DataImplement;
using Data.Repository;
using Data.Services;
using Entity.Dto.Default;
using Entity.Dto.Select;
using Entity.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web.AutoMapper;

namespace Web.Service
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // 🔹 AutoMapper (registro manual compatible con AutoMapper 15)
            services.AddSingleton<IMapper>(sp =>
            {
                var loggerFactory = sp.GetService<ILoggerFactory>();
                var expr = new MapperConfigurationExpression();
                expr.AddProfile(new AutoMapperProfile());
                var mappingConfig = new MapperConfiguration(expr, loggerFactory);
                return mappingConfig.CreateMapper();
            });

            // 🔹 Repositorio genérico
            services.AddScoped(typeof(IData<>), typeof(DataGeneric<>));

            // 🔹 Repositorios específicos
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolUserRepository, RolUserRepository>();
            services.AddScoped<IFormModuleRepository, FormModuleRepository>();
            services.AddScoped<IRolFormPermissionRepository, RolFormPermissionRepository>();

            // 🔹 Servicios (Business) - Seguridad
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRolBusiness, RolBusiness>();
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IFormBusiness, FormBusiness>();
            services.AddScoped<IModuleBusiness, ModuleBusiness>();
            services.AddScoped<IPermissionBusiness, PermissionBusiness>();
            services.AddScoped<IRolUserBusiness, RolUserBusiness>();
            services.AddScoped<IFormModuleBusiness, FormModuleBusiness>();
            services.AddScoped<IRolFormPermissionBusiness, RolFormPermissionBusiness>();
            services.AddScoped<IBaseBusiness<Form, FormDto, FormSelectDto>, FormBusiness>();

            return services;
        }
    }
}
