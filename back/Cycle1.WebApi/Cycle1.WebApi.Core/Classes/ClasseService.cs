using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Classes
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ClasseService : ServiceBase<ClasseService>, IClasseService
    {
        private readonly IClasseDal _classeDal;

        public ClasseService(ILogger<ClasseService> logger, IClasseDal classeDal) : base(logger)
        {
            this._classeDal = classeDal;
        }

        public async Task<Result<Classe>> ChargerClasse(int classeId)
        {
            return await this._classeDal.ChargerClasse(classeId);
        }
    }

}
