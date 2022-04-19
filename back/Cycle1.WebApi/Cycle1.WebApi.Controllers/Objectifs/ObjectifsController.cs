using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Objectifs;
using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ObjectifsController : ControllerBase<ObjectifsController, IObjectifService>
    {
        protected override ResourceManager? ResourceManager => EleveResources.ResourceManager;

        public ObjectifsController(IObjectifService service, ILogger<ObjectifsController> logger) : base(service, logger) { }


        [HttpGet($"~/{Routes.BaseRouteV1}objectifs/")]
        public async Task<IActionResult> ChargerListeObjectif()
        {
            Result<List<Objectif>> resultat = await this.Service.ChargerListeObjectif();
            return this.GetActionResult(resultat);
        }

    }
}