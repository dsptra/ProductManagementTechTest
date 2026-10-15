using AXA.Mandiri.Technical.Test.Application.Contracts;
using AXA.Mandiri.Technical.Test.Infrastructure.Persistance;
using AXA.Mandiri.Technical.Test.Infrastructure.Repositories;
using AXA.Mandiri.Technical.Test.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AXA.Mandiri.Technical.Test.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddDbInstaller(configuration);

            services.AddJwtAuthentication();

            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
