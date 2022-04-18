using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.ObjectifEleves
{
    /// <summary>
    /// Interface de service pour les élèves
    /// </summary>
    public interface IObjectifEleveService
    {
        Task<Result<ObjectifEleve>> ChargerObjectifEleve(int eleveId, int objectifId);
        Task<Result<List<ObjectifEleve>>> ChargerListeObjectifEleveEleve(int eleveId);
    }
}
