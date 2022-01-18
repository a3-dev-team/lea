using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.MySql.Classes;
using A3.Lea.Cycle1.WebApi.MySql.Eleves;
using A3.Library.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    /// <summary>
    /// Classe d'extension pour l'ajout des services du domaine "cycle 1"
    /// </summary>
    internal static class ServiceCollectionCycle1Extension
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
        private static void AddServices<TIService, TService, TIDal, TDal, TProblemDetailsResolver>(IServiceCollection services, Func<IServiceProvider, TProblemDetailsResolver> problemDetailsResolverFactory)
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

        /// <summary>
        /// Ajoute les services pour le contexte "eleves" du domaine "cycle 1"
        /// </summary>
        /// <param name="services"></param>
        private static void AddElevesServices(IServiceCollection services)
        {
            AddServices<IElevesService, ElevesService, IElevesDal, ElevesDalMySql, ElevesProblemDetailsResolver>
                (services, (serviceProvider) => new ElevesProblemDetailsResolver(0, 999));
        }

        /// <summary>
        /// Ajoute les services pour le contexte "classes" du domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        private static void AddClassesServices(IServiceCollection services)
        {
            AddServices<IClassesService, ClassesService, IClassesDal, ClassesDalMySql, ClassesProblemDetailsResolver>
                (services, (serviceProvider) => new ClassesProblemDetailsResolver(1000, 1999));
        }

        /// <summary>
        /// Ajoute les services pour le domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        public static void AddCycle1Services(this IServiceCollection services)
        {
            AddElevesServices(services);
            AddClassesServices(services);
        }
    }
}
