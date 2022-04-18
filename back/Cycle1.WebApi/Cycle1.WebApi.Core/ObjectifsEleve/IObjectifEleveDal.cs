using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.ObjectifEleves
{
    /// <summary>
    /// Interface dal pour les élèves
    /// </summary>
    public interface IObjectifEleveDal
    {
        Task<Result<ObjectifEleve>> ChargerObjectifEleve(int eleveId, int objectifId);
        Task<Result<List<ObjectifEleve>>> ChargerListeObjectifEleveEleve(int eleveId);
    }
}
