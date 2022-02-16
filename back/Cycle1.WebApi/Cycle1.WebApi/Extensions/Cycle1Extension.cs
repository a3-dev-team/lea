using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Dal.Classes;
using A3.Lea.Cycle1.WebApi.Dal.Eleves;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    /// <summary>
    /// Classe d'extension pour l'ajout des services du domaine "cycle 1"
    /// </summary>
    internal static class Cycle1Extension
    {
        /// <summary>
        /// Ajoute les services pour le contexte "eleves" du domaine "cycle 1"
        /// </summary>
        /// <param name="services"></param>
        private static void AddElevesServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IElevesService, ElevesService, IElevesDal, ElevesDal, ElevesProblemDetailsResolver>
                (services, (serviceProvider) => new ElevesProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le contexte "classes" du domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        private static void AddClassesServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IClassesService, ClassesService, IClassesDal, ClassesDal, ClassesProblemDetailsResolver>
                (services, (serviceProvider) => new ClassesProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        public static IServiceCollection AddCycle1Services(this IServiceCollection services)
        {
            AddElevesServices(services);
            AddClassesServices(services);
            return services;
        }
    }
}
