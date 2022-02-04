using Serilog;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    /// <summary>
    /// Classe d'extension pour la gestion des logs
    /// </summary>
    public static class LoggingExtension
    {
        public static IHostBuilder UseLogging(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
