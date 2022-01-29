using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Library.Mvc;
using A3.Library.Results;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ElevesController : ControllerBase<ElevesController, IElevesService>
    {
        protected override ResourceManager? ResourceManager => ElevesResources.ResourceManager;

        [HttpGet("cookie/{idClasse}")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult CookieGet(int idClasse)
        {
            Result<List<IdentiteEleve>> resultat = this.Service.ObtenirListeIdentiteEleve(idClasse);
            return this.GetActionResult(resultat);
        }

        [HttpGet("token/{idClasse}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult TokenGet(int idClasse)
        {
            Result<List<IdentiteEleve>> resultat = this.Service.ObtenirListeIdentiteEleve(idClasse);
            return this.GetActionResult(resultat);
        }

        public ElevesController(IElevesService elevesService, ILogger<ElevesController> logger) : base(elevesService, logger) { }
    }
}