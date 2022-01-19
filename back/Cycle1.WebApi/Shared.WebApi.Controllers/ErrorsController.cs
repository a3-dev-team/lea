using A3.Library.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Shared.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase<ErrorsController>
    {
        private Exception? GetException()
        {
            return this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            this.Logger.LogError(this.GetException(), "Une erreur non gérée est survenue");
            // L'appel à Problem va faire appel au middleware de gestion des ProblemDetails
            // qui va s'occuper de transformer l'erreur en ProblemDetails avec un StatutCode à 500 (Internal Server Error)
            return this.Problem();
        }

        public ErrorsController(ILogger<ErrorsController> logger) : base(logger) { }
    }
}
