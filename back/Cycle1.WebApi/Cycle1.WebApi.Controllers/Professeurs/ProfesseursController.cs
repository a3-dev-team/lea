using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Professeurs;
using A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers.Professeurs
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ProfesseursController : ControllerBase<ProfesseursController, IProfesseurService>
    {
        protected override ResourceManager? ResourceManager => ProfesseurResources.ResourceManager;

        public ProfesseursController(IProfesseurService service, ILogger<ProfesseursController> logger) : base(service, logger) { }

        [HttpGet("{email}")]
        public async Task<IActionResult> ChargerProfesseurParEmail(string email)
        {
            Result<Professeur> resultat = await this.Service.ChargerProfesseurParEmail(email);
            return this.GetActionResult(resultat);
        }
    }
}
