using A3.Lea.Cycle1.WebApi.Core.Professeurs;
using A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal.Professeurs
{
    /// <summary>
    /// Classe dal pour les élèves
    /// </summary>
    public class ProfesseurDal : EntityFrameworkDalBase<Professeur>, IProfesseurDal
    {
        public ProfesseurDal(Cycle1DbContext databaseContext) : base(databaseContext) { }

        public async Task<Result<Professeur>> ChargerProfesseur(int professeurId)
        {
            return new Result<Professeur>()
            {
                Value = await this.FindByCondition(professeur => professeur.Id.Equals(professeurId)).SingleOrDefaultAsync()
            };
        }

        public async Task<Result<Professeur>> ChargerProfesseurParEmail(string email)
        {
            return new Result<Professeur>()
            {
                Value = await this.FindByCondition(professeur => professeur.Email.Equals(email)).SingleOrDefaultAsync()
            };
        }
    }
}