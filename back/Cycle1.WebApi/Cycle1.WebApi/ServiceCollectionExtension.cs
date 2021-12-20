using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Dal.Eleves;

namespace A3.Lea.Cycle1.WebApi
{
    internal static class ServiceCollectionExtension
    {
        private static void AddElevesServices(IServiceCollection services)
        {
            services.AddTransient<IElevesDal, ElevesDalMySql>();
            services.AddTransient<IElevesService, ElevesService>();
        }

        public static void AddCycle1Service(this IServiceCollection services)
        {
            AddElevesServices(services);
        }
    }
}
