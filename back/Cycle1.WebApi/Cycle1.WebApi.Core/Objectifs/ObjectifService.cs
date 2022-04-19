using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Objectifs
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ObjectifService : ServiceBase<ObjectifService>, IObjectifService
    {
        private readonly IObjectifDal _objectifDal;

        public ObjectifService(ILogger<ObjectifService> logger, IObjectifDal objectifDal) : base(logger)
        {
            this._objectifDal = objectifDal;
        }

        // public async Task<Result<Objectif>> ChargerObjectif(int objectifId)
        // {
        //     return await this._elevesDal.ChargerObjectif(objectifId);
        // }

        public async Task<Result<List<Objectif>>> ChargerListeObjectif()
        {
            return await this._objectifDal.ChargerListeObjectif();
        }
    }
}
