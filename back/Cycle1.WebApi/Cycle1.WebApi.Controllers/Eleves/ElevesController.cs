using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ElevesController : ControllerBase<ElevesController, IEleveService>
    {
        protected override ResourceManager? ResourceManager => EleveResources.ResourceManager;

        [HttpGet($"~/{Routes.BaseRouteV1}classes/{{classeId:int}}/eleves")]
        public async Task<IActionResult> ChargerListeEleveClasse(int classeId)
        {
            Result<List<Eleve>> resultat = await this.Service.ChargerListeEleveClasse(classeId);
            return this.GetActionResult(resultat);
        }

        public ElevesController(IEleveService service, ILogger<ElevesController> logger) : base(service, logger) { }
    }
}