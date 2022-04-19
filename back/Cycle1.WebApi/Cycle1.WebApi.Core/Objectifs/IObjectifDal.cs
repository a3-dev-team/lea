using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Objectifs
{
    /// <summary>
    /// Interface dal pour les élèves
    /// </summary>
    public interface IObjectifDal
    {
        // Task<Result<Objectif>> ChargerObjectif(int objectifId);
        Task<Result<List<Objectif>>> ChargerListeObjectif();
    }
}
