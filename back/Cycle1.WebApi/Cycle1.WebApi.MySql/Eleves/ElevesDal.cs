using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;

namespace A3.Lea.Cycle1.WebApi.MySql.Eleves
{
    public class ElevesDalMySql : IElevesDal
    {
        public List<CarteIdentiteEleve> GetListeCarteIdentiteEleve(int idClasse)
        {
            using (var databaseContext = new DatabaseContext())
            {
                return databaseContext.Set<CarteIdentiteEleve>().Select((e) => e).ToList();
            }
        }

        public List<Eleve> GetListeEleve(int idClasse)
        {
            using (var databaseContext = new DatabaseContext())
            {
                return databaseContext.Set<Eleve>().Select((e) => e).ToList();
            }
        }
    }
}
