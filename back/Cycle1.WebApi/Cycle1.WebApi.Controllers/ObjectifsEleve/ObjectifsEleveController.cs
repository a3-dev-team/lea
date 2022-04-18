using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.ObjectifEleves;
using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ObjectifsEleveController : ControllerBase<ObjectifsEleveController, IObjectifEleveService>
    {
        protected override ResourceManager? ResourceManager => EleveResources.ResourceManager;

        public ObjectifsEleveController(IObjectifEleveService service, ILogger<ObjectifsEleveController> logger) : base(service, logger) { }

        [HttpGet($"~/{Routes.BaseRouteV1}eleves/{{eleveId:int}}/objectifs/{{objectifId:int}}")]
        public async Task<IActionResult> ChargerEleve(int eleveId, int objectifId)
        {
            Result<ObjectifEleve> resultat = await this.Service.ChargerObjectifEleve(eleveId, objectifId);
            return this.GetActionResult(resultat);
        }

        [HttpGet($"~/{Routes.BaseRouteV1}eleves/{{eleveId:int}}/objectifs")]
        public async Task<IActionResult> ChargerListeObjectifEleveEleve(int eleveId)
        {
            Result<List<ObjectifEleve>> resultat = await this.Service.ChargerListeObjectifEleveEleve(eleveId);
            return this.GetActionResult(resultat);
        }

    }
}