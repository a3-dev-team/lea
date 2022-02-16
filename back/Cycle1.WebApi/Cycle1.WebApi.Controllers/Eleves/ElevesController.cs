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
    public class ElevesController : ControllerBase<ElevesController, IElevesService>
    {
        protected override ResourceManager? ResourceManager => ElevesResources.ResourceManager;

        [HttpGet("{idClasse}")]
        public async Task<IActionResult> Get(int idClasse)
        {
            Result<List<Eleve>> resultat = await this.Service.ObtenirListeEleve(idClasse);
            return this.GetActionResult(resultat);
        }

        public ElevesController(IElevesService elevesService, ILogger<ElevesController> logger) : base(elevesService, logger) { }
    }
}