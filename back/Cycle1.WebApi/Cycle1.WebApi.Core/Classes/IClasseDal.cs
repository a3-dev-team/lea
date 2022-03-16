using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Interface dal pour les classes
    /// </summary>
    public interface IClasseDal
    {
        Task<Result<Classe>> ChargerClasse(int classeId);

    }
}
