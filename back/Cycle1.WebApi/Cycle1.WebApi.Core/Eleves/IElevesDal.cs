using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    /// <summary>
    /// Interface dal pour les élèves
    /// </summary>
    public interface IElevesDal
    {
        Result<List<IdentiteEleve>> ObtenirListeIdentiteEleve(int idClasse);
    }
}
