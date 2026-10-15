using Microsoft.AspNetCore.Builder;
using Serilog;

namespace AXA.Mandiri.Technical.Test.Infrastructure.Logging
{
    public static class LogInstaller
    {
        public static void AddSerilogLogging(this ConfigureHostBuilder host)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .CreateLogger();

            host.UseSerilog();
        }
    }
}
