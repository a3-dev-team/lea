using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Objectifs
{
    /// <summary>
    /// Interface de service pour les élèves
    /// </summary>
    public interface IObjectifService
    {
        // Task<Result<Objectif>> ChargerObjectif(int eleveId);
        Task<Result<List<Objectif>>> ChargerListeObjectif();
    }
}
