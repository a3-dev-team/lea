using A3.Library.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErreurController : ControllerBase<ErreurController>
    {
        private Exception? GetException()
        {
            return this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        }

        [Route("/erreur")]
        public IActionResult Erreur()
        {
            this.Logger.LogError(this.GetException(), "Une erreur non gérée est survenue");
            // L'appel à Problem va faire appel au middleware de gestion des ProblemDetails
            // qui va s'occuper de transformer l'erreur en ProblemDetails avec un StatutCode à 500 (Internal Server Error)
            return this.Problem();
        }

        public ErreurController(ILogger<ErreurController> logger) : base(logger) { }
    }
}
