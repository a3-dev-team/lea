using A3.Library.Mvc.ProblemsDetails;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    internal static class ServicesExtensionHelper
    {
        /// <summary>
        /// Ajoute dans le moteur d'injection de dépendance, toutes les interfaces et leurs implémentations nécessaire au fonctionnement d'un context
        /// </summary>
        /// <typeparam name="TIService">Type interface de service</typeparam>
        /// <typeparam name="TService">Type implementation de service</typeparam>
        /// <typeparam name="TIDal">Type interface Dal</typeparam>
        /// <typeparam name="TDal">Type implémentation Dal</typeparam>
        /// <typeparam name="TProblemDetailsResolver">Type implementation </typeparam>
        /// <param name="services">Collection de service</param>
        /// <param name="problemDetailsResolverFactory">Fabrique d'implementation de <see cref="IProblemDetailsResolver"/></param>
        public static void AddServices<TIService, TService, TIDal, TDal, TProblemDetailsResolver>(IServiceCollection services, Func<IServiceProvider, TProblemDetailsResolver> problemDetailsResolverFactory)
            where TIService : class
            where TService : class, TIService
            where TIDal : class
            where TDal : class, TIDal
            where TProblemDetailsResolver : class, IProblemDetailsResolver
        {
            services.AddSingleton<TIService, TService>();
            services.AddSingleton<TIDal, TDal>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IProblemDetailsResolver, TProblemDetailsResolver>(problemDetailsResolverFactory));
        }
    }
}
