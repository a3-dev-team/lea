using A3.Lea.Cycle1.WebApi.Core.Classes;
using A3.Library.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace A3.Lea.Cycle1.WebApi.Controllers.Classes
{
    [ApiController]
    [Route("api/lea/cycle1/v1/classes")]
    public class ClassesController : ControllerBase<ClassesController, IClassesService>
    {
        public ClassesController(IClassesService elevesService, ILogger<ClassesController> logger) : base(elevesService, logger) { }
    }
}
