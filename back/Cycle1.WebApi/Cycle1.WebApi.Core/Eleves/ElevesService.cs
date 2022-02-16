using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ElevesService : ServiceBase<ElevesService>, IElevesService
    {
        private readonly IElevesDal _elevesDal;

        public ElevesService(ILogger<ElevesService> logger, IElevesDal elevesDal) : base(logger)
        {
            this._elevesDal = elevesDal;
        }

        public async Task<Result<List<Eleve>>> ObtenirListeIdentiteEleve(int idClasse)
        {
            if (idClasse == 0)
            {
                this.Logger.LogDebug("Identifiant de classe rejeté {0}", idClasse);
                return new Result<List<Eleve>>().AddError("Pas le droit de charger une classe");
            }
            if (idClasse == 1)
            {
                this.Logger.LogDebug("Identifiant de classe rejeté {0}", idClasse);
                return new Result<List<Eleve>>().AddError("Erreur non resolvable");
            }
            this.Logger.LogDebug("Identifiant de classe accepté {0}", idClasse);
            return await this._elevesDal.ObtenirListeIdentiteEleve(idClasse);
        }

    }
}
