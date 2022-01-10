using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.MySql.Classes;
using A3.Lea.Cycle1.WebApi.MySql.Eleves;
using A3.Library.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    /// <summary>
    /// Classe d'extension pour l'ajout des services du cycle 1
    /// </summary>
    internal static class ServiceCollectionCycle1Extension
    {
        private static void AddServices<TIService, TService, TIDal, TDal, TProblem>(IServiceCollection services, Func<IServiceProvider, TProblem> problemDetailsResolverFactory)
            where TIService : class
            where TService : class, TIService
            where TIDal : class
            where TDal : class, TIDal
            where TProblem : class, IProblemDetailsResolver
        {
            services.AddTransient<TIService, TService>();
            services.AddTransient<TIDal, TDal>();
            services.TryAddEnumerable(ServiceDescriptor.Transient<IProblemDetailsResolver, TProblem>(problemDetailsResolverFactory));
        }

        private static void AddElevesServices(IServiceCollection services)
        {
            AddServices<IElevesService, ElevesService, IElevesDal, ElevesDalMySql, ElevesProblemDetailsResolver>
                (services, (serviceProvider) => new ElevesProblemDetailsResolver(0, 999));
        }

        private static void AddClassesServices(IServiceCollection services)
        {
            AddServices<IClassesService, ClassesService, IClassesDal, ClassesDalMySql, ClassesProblemDetailsResolver>
                (services, (serviceProvider) => new ClassesProblemDetailsResolver(1000, 1999));
        }

        public static void AddCycle1Services(this IServiceCollection services)
        {
            AddElevesServices(services);
            AddClassesServices(services);
        }
    }
}
