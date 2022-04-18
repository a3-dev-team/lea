using A3.Lea.Cycle1.WebApi.Core.ObjectifEleves;
using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal.ObjectifEleves
{
    /// <summary>
    /// Classe dal pour les élèves
    /// </summary>
    public class ObjectifEleveDal : EntityFrameworkDalBase<ObjectifEleve>, IObjectifEleveDal
    {
        public ObjectifEleveDal(Cycle1DbContext databaseContext) : base(databaseContext) { }

        public async Task<Result<ObjectifEleve>> ChargerObjectifEleve(int eleveId, int objectifId)
        {
            return new Result<ObjectifEleve>()
            {
                Value = await this.FindByCondition(objectifEleve => objectifEleve.EleveId.Equals(eleveId) && objectifEleve.ObjectifId.Equals(objectifId)).SingleOrDefaultAsync()
            };
        }

        public async Task<Result<List<ObjectifEleve>>> ChargerListeObjectifEleveEleve(int eleveId)
        {
            return new Result<List<ObjectifEleve>>()
            {
                Value = await this.FindByCondition(objectifEleve => objectifEleve.EleveId.Equals(eleveId)).ToListAsync()
            };
        }

    }
}