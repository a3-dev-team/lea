using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers.Classes
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ClassesController : ControllerBase<ClassesController, IClasseService>
    {
        protected override ResourceManager? ResourceManager => ClasseResources.ResourceManager;

        public ClassesController(IClasseService service, ILogger<ClassesController> logger) : base(service, logger) { }

        [HttpGet("{classeId:int}")]
        public async Task<IActionResult> ChargerClasse(int classeId)
        {
            Result<Classe> resultat = await this.Service.ChargerClasse(classeId);
            return this.GetActionResult(resultat);
        }
    }
}
