using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Dal.MySql.Classes;
using A3.Lea.Cycle1.WebApi.Dal.MySql.Eleves;

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
            ServicesExtensionHelper.AddServices<IElevesService, ElevesService, IElevesDal, ElevesDalMySql, ElevesProblemDetailsResolver>
                (services, (serviceProvider) => new ElevesProblemDetailsResolver(10000, 10999));
        }

        /// <summary>
        /// Ajoute les services pour le contexte "classes" du domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        private static void AddClassesServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IClassesService, ClassesService, IClassesDal, ClassesDalMySql, ClassesProblemDetailsResolver>
                (services, (serviceProvider) => new ClassesProblemDetailsResolver(11000, 11999));
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
