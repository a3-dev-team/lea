using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Professeurs;
using A3.Library.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers.Professeurs
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ProfesseursController : ControllerBase<ProfesseursController, IProfesseurService>
    {
        protected override ResourceManager? ResourceManager => ProfesseurResources.ResourceManager;

        public ProfesseursController(IProfesseurService service, ILogger<ProfesseursController> logger) : base(service, logger) { }
    }
}
