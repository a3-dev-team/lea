using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.ObjectifEleves
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ObjectifEleveService : ServiceBase<ObjectifEleveService>, IObjectifEleveService
    {
        private readonly IObjectifEleveDal _objectifsDal;

        public ObjectifEleveService(ILogger<ObjectifEleveService> logger, IObjectifEleveDal objectifsDal) : base(logger)
        {
            this._objectifsDal = objectifsDal;
        }

        public async Task<Result<ObjectifEleve>> ChargerObjectifEleve(int eleveId, int objectifId)
        {
            return await this._objectifsDal.ChargerObjectifEleve(eleveId, objectifId);
        }

        public async Task<Result<List<ObjectifEleve>>> ChargerListeObjectifEleveEleve(int eleveId)
        {
            return await this._objectifsDal.ChargerListeObjectifEleveEleve(eleveId);
        }
    }
}
