using System.Resources;
using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Library.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers.Classes
{
    [Route(Routes.ControllerBaseRouteV1)]
    public class ClassesController : ControllerBase<ClassesController, IClassesService>
    {
        protected override ResourceManager? ResourceManager => ClassesResources.ResourceManager;

        public ClassesController(IClassesService elevesService, ILogger<ClassesController> logger) : base(elevesService, logger) { }
    }
}
