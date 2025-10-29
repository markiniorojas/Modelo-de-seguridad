using Business.Implementations.Model_Security;
using Business.Interfaces.Model_Security;
using Data.Interfaces.DataBasic;
using Data.Interfaces.DataImplement;
using Data.Repository;
using Data.Services;
using Web.AutoMapper;

namespace Web.Service
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Auto Mapper 
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //Data generica
            services.AddScoped(typeof(IData<>), typeof(DataGeneric<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolUserRepository, RolUserRepository>();
            services.AddScoped<IFormModuleRepository, FormModuleRepository>();
            services.AddScoped<IRolFormPermissionRepository, RolFormPermissionRepository>();

              // Servicios — SECURITY
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRolBusiness, RolBusiness>();
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IFormBusiness, FormBusiness>();
            services.AddScoped<IModuleBusiness, ModuleBusiness>();
            services.AddScoped<IPermissionBusiness, PermissionBusiness>();
            services.AddScoped<IRolUserBusiness, RolUserBusiness>();
            services.AddScoped<IFormModuleBusiness, FormModuleBusiness>();
            services.AddScoped<IRolFormPermissionBusiness, RolFormPermissionBusiness>();


            return services;
        }
    }
}
