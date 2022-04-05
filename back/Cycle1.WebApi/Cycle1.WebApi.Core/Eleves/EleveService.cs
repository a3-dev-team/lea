using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class EleveService : ServiceBase<EleveService>, IEleveService
    {
        private readonly IEleveDal _elevesDal;

        public EleveService(ILogger<EleveService> logger, IEleveDal elevesDal) : base(logger)
        {
            this._elevesDal = elevesDal;
        }

        public async Task<Result<Eleve>> ChargerEleve(int eleveId)
        {
            return await this._elevesDal.ChargerEleve(eleveId);
        }

        public async Task<Result<List<Eleve>>> ChargerListeEleveClasse(int classeId)
        {
            return await this._elevesDal.ChargerListeEleveClasse(classeId);
        }
    }
}
