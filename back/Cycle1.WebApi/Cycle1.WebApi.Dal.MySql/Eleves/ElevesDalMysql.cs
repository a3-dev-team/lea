using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Dal.MySql.Eleves
{
    /// <summary>
    /// Classe dal pour les élèves
    /// </summary>
    public class ElevesDalMySql : IElevesDal
    {
        public Result<List<IdentiteEleve>> ObtenirListeIdentiteEleve(int idClasse)
        {
            return new Result<List<IdentiteEleve>>()
            {
                Value = new List<IdentiteEleve>()
                {
                    new IdentiteEleve(1, "DOLET", "Bertrand", Core.Commun.Sexe.Masculin, Core.Commun.Niveau.GrandeSection, null)
                }
            };
        }
    }
}