using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Interface de service pour les classes
    /// </summary>
    public interface IClasseService
    {
        Task<Result<Classe>> ChargerClasse(int classeId);
    }
}
