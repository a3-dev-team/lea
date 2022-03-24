using A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Core.Professeurs
{
    /// <summary>
    /// Classe implémentation de service pour les élèves
    /// </summary>
    public class ProfesseurService : ServiceBase<ProfesseurService>, IProfesseurService
    {
        private readonly IProfesseurDal _professeursDal;

        public ProfesseurService(ILogger<ProfesseurService> logger, IProfesseurDal professeursDal) : base(logger)
        {
            this._professeursDal = professeursDal;
        }

        public async Task<Result<Professeur>> ChargerProfesseur(int professeurId)
        {
            return await this._professeursDal.ChargerProfesseur(professeurId);
        }

        public async Task<Result<Professeur>> ChargerProfesseurParEmail(string email)
        {
            return await this._professeursDal.ChargerProfesseurParEmail(email);
        }
    }
}
