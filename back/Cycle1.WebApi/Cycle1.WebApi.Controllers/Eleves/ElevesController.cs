using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [ApiController]
    [Route("api/lea/cycle1/v1/eleves")]
    public class ElevesController : ControllerBase<ElevesController, IElevesService>
    {
        [HttpGet("{idClasse}")]
        public IActionResult Get(int idClasse)
        {
            Result<List<IdentiteEleve>> resultat = this.Service.ObtenirListeIdentiteEleve(idClasse);
            return this.GetActionResult(resultat);
        }

        public ElevesController(IElevesService elevesService, ILogger<ElevesController> logger) : base(elevesService, logger) { }
    }
}