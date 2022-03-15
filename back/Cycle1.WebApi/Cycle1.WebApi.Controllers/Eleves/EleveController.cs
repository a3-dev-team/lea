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
    public class EleveController : ControllerBase<EleveController, IEleveService>
    {
        protected override ResourceManager? ResourceManager => EleveResources.ResourceManager;

        [HttpGet("{classeId}")]
        public async Task<IActionResult> Get(int classeId)
        {
            Result<List<Eleve>> resultat = await this.Service.ObtenirListeEleve(classeId);
            return this.GetActionResult(resultat);
        }

        public EleveController(IEleveService service, ILogger<EleveController> logger) : base(service, logger) { }
    }
}