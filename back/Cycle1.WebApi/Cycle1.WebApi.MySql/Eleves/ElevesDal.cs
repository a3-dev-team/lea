using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;

namespace A3.Lea.Cycle1.WebApi.MySql.Eleves
{
    public class ElevesDalMySql : IElevesDal
    {
        public List<CarteIdentiteEleve> GetListeCarteIdentiteEleve(int idClasse)
        {
            return new List<CarteIdentiteEleve>() 
            { 
                new CarteIdentiteEleve(1, "DOLET", "Bertrand", Core.Commun.Sexe.Masculin, Core.Commun.Niveau.GrandeSection, null)
            };
        }
    }
}
