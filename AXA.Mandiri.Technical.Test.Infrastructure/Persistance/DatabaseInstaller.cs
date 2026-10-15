using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AXA.Mandiri.Technical.Test.Infrastructure.Persistance
{
    public static class DatabaseInstaller
    {
        public static IServiceCollection AddDbInstaller(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestContext>(options =>
                options
                    .UseNpgsql(configuration.GetConnectionString("PostgresConnection"))
                .UseSnakeCaseNamingConvention()
            );
            return services;
        }
    }
}