using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using A3ProblemDetailsFactory = A3.Library.Mvc.ProblemDetailsFactory;
using HellangProblemDetailsFactory = Hellang.Middleware.ProblemDetails.ProblemDetailsFactory;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    /// <summary>
    /// Classe d'extension pour une gestion personnalisée du middleware <see cref="Hellang.Middleware.ProblemDetails"/>
    /// </summary>
    public static class ProblemDetailsExtension
    {
        public static IServiceCollection AddProblemDetails(this IServiceCollection services)
        {
            return services.AddProblemDetails(null);
        }

        public static IServiceCollection AddProblemDetails(this IServiceCollection services, Action<ProblemDetailsOptions>? configure)
        {
            if (configure != null)
            {
                services.Configure(configure);
            }

            services.TryAddSingleton<HellangProblemDetailsFactory, A3ProblemDetailsFactory>();
            services.TryAddEnumerable(ServiceDescriptor.Transient<IConfigureOptions<ProblemDetailsOptions>, ProblemDetailsOptionsSetup>());
            return services;
        }

        public static IApplicationBuilder UseProblemDetails(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ProblemDetailsMiddleware>(Array.Empty<object>());
        }
    }
}
