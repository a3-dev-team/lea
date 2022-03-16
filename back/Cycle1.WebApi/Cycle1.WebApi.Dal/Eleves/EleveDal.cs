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
    public class EleveDal : EntityFrameworkDalBase<Eleve>, IEleveDal
    {
        public EleveDal(Cycle1DbContext databaseContext) : base(databaseContext) { }

        public async Task<Result<List<Eleve>>> ChargerListeEleveClasse(int classeId)
        {
            return new Result<List<Eleve>>()
            {
                Value = await this.FindByCondition(eleve => eleve.ClasseId.Equals(classeId)).ToListAsync()
            };
        }
    }
}