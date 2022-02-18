using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal.Eleves
{
    /// <summary>
    /// Classe dal pour les élèves
    /// </summary>
    public class ElevesDal : DalBase<Eleve>, IElevesDal
    {

        public ElevesDal(DatabaseContext databaseContext)
        : base(databaseContext)
        { }

        public async Task<Result<List<Eleve>>> ObtenirListeEleve(int idClasse)
        {
            return new Result<List<Eleve>>()
            {
                Value = await this.FindByCondition(e => e.ClasseId.Equals(idClasse)).ToListAsync()
            };
        }

    }

}