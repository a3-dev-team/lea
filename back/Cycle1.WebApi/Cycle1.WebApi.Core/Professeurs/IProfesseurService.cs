using A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles;
using A3.Library.Results;

namespace A3.Lea.Cycle1.WebApi.Core.Professeurs
{
    /// <summary>
    /// Interface de service pour les élèves
    /// </summary>
    public interface IProfesseurService
    {
        Task<Result<Professeur>> ChargerProfesseur(int professeurId);
        Task<Result<Professeur>> ChargerProfesseurParEmail(string eMail);
    }
}
