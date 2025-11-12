using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Application.Services;

namespace Sofis.Api.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
