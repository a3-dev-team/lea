using A3.Lea.Cycle1.WebApi.Core.Objectifs;
using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal.Objectifs
{
    /// <summary>
    /// Classe dal pour les élèves
    /// </summary>
    public class ObjectifDal : EntityFrameworkDalBase<Objectif>, IObjectifDal
    {
        public ObjectifDal(Cycle1DbContext databaseContext) : base(databaseContext) { }

        // public async Task<Result<Objectif>> ChargerObjectif(int eleveId)
        // {
        //     return new Result<Objectif>()
        //     {
        //         Value = await this.FindByCondition(eleve => eleve.Id.Equals(eleveId)).SingleOrDefaultAsync()
        //     };
        // }

        public async Task<Result<List<Objectif>>> ChargerListeObjectif()
        {
            return new Result<List<Objectif>>()
            {
                Value = await this.FindAll().ToListAsync()
            };
        }

    }
}