using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal.Classes
{
    /// <summary>
    /// Classe dal pour les classes
    /// </summary>
    public class ClasseDal : EntityFrameworkDalBase<Classe>, IClasseDal
    {
        public ClasseDal(Cycle1DbContext databaseContext) : base(databaseContext) { }

        public async Task<Result<Classe>> ChargerClasse(int classeId)
        {
            return new Result<Classe>()
            {
                Value = await this.FindByCondition(classe => classe.Id.Equals(classeId)).SingleOrDefaultAsync()
            };
        }
    }
}