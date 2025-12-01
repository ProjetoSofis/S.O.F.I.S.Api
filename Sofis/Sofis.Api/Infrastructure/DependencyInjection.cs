using Microsoft.EntityFrameworkCore;
using Sofis.Api.Application.Contracts;
using Sofis.Api.Application.Interfaces;
using Sofis.Api.Application.Services;
using Sofis.Api.Infrastructure.Auth;
using Sofis.Api.Infrastructure.Persistence.Repositories;

namespace Sofis.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<SofisDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IEmailService, SmtpEmailService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
