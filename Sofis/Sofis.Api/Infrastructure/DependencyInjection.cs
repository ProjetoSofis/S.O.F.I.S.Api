using Sofis.Api.Application.Interfaces;
using Sofis.Api.Infrastructure.Persistence.Repositories;

namespace Sofis.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddScoped<IChildRepository, ChildRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            return services;
        }
    }
}
