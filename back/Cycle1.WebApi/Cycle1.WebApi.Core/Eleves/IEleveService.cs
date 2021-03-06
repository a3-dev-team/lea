using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    /// <summary>
    /// Interface de service pour les élèves
    /// </summary>
    public interface IEleveService
    {
        Task<Result<Eleve>> ChargerEleve(int eleveId);
        Task<Result<List<Eleve>>> ChargerListeEleveClasse(int classeId);
    }
}
