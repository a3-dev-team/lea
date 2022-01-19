using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;

namespace A3.Lea.Cycle1.WebApi.MySql.Eleves
{
    public class ElevesDalMySql : IElevesDal
    {
        DatabaseContext _databaseContext;
        public ElevesDalMySql(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public List<CarteIdentiteEleve> GetListeCarteIdentiteEleve(int idClasse)
        {
            return this._databaseContext.Set<CarteIdentiteEleve>().Select((e) => e).ToList();
        }

        public List<Eleve> GetListeEleve(int idClasse)
        {
            return this._databaseContext.Set<Eleve>().Select((e) => e).ToList();
        }
    }
}
