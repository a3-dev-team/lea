using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.ObjectifEleves;
using A3.Lea.Cycle1.WebApi.Core.Objectifs;
using A3.Lea.Cycle1.WebApi.Core.Professeurs;
using A3.Lea.Cycle1.WebApi.Dal.Classes;
using A3.Lea.Cycle1.WebApi.Dal.Eleves;
using A3.Lea.Cycle1.WebApi.Dal.ObjectifEleves;
using A3.Lea.Cycle1.WebApi.Dal.Objectifs;
using A3.Lea.Cycle1.WebApi.Dal.Professeurs;

namespace A3.Lea.Cycle1.WebApi.Extensions
{
    /// <summary>
    /// Classe d'extension pour l'ajout des services du domaine "cycle 1"
    /// </summary>
    internal static class Cycle1Extension
    {
        /// <summary>
        /// Ajoute les services pour le contexte "professeurs" du domaine "cycle 1"
        /// </summary>
        // /// <param name="services">Collection de service</param>
        // private static void AddEcolesServices(IServiceCollection services)
        // {
        //     ServicesExtensionHelper.AddServices<IEcoleService, EcoleService, IEcoleDal, EcoleDal, EcoleProblemDetailsResolver>
        //         (services, (serviceProvider) => new EcoleProblemDetailsResolver());
        // }

        /// <summary>
        /// Ajoute les services pour le contexte "professeurs" du domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        private static void AddProfesseursServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IProfesseurService, ProfesseurService, IProfesseurDal, ProfesseurDal, ProfesseurProblemDetailsResolver>
                (services, (serviceProvider) => new ProfesseurProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le contexte "classes" du domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        private static void AddClassesServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IClasseService, ClasseService, IClasseDal, ClasseDal, ClasseProblemDetailsResolver>
                (services, (serviceProvider) => new ClasseProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le contexte "eleves" du domaine "cycle 1"
        /// </summary>
        /// <param name="services"></param>
        private static void AddElevesServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IEleveService, EleveService, IEleveDal, EleveDal, EleveProblemDetailsResolver>
                (services, (serviceProvider) => new EleveProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le contexte "objectifs" du domaine "cycle 1"
        /// </summary>
        /// <param name="services"></param>
        private static void AddObjectifsServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IObjectifService, ObjectifService, IObjectifDal, ObjectifDal, ObjectifProblemDetailsResolver>
                (services, (serviceProvider) => new ObjectifProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le contexte "objectifs eleves" du domaine "cycle 1"
        /// </summary>
        /// <param name="services"></param>
        private static void AddObjectifsElevesServices(IServiceCollection services)
        {
            ServicesExtensionHelper.AddServices<IObjectifEleveService, ObjectifEleveService, IObjectifEleveDal, ObjectifEleveDal, ObjectifEleveProblemDetailsResolver>
                (services, (serviceProvider) => new ObjectifEleveProblemDetailsResolver());
        }

        /// <summary>
        /// Ajoute les services pour le domaine "cycle 1"
        /// </summary>
        /// <param name="services">Collection de service</param>
        public static IServiceCollection AddCycle1Services(this IServiceCollection services)
        {
            // AddEcolesServices(services);
            AddProfesseursServices(services);
            AddElevesServices(services);
            AddObjectifsServices(services);
            AddObjectifsElevesServices(services);
            AddClassesServices(services);
            return services;
        }
    }
}
