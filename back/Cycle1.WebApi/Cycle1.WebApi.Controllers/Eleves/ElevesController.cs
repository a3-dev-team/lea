
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using Microsoft.AspNetCore.Mvc;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [ApiController]
    [Route("api/lea/cycle1/v1/[controller]")]
    public class ElevesController : ControllerBase
    {
        private readonly IElevesService _elevesService;

        [HttpGet(Name = "GetListeIdentiteEleve")]
        public IEnumerable<CarteIdentiteEleve> Get()
        {
            return new List<CarteIdentiteEleve>();
        }

        public ElevesController(IElevesService elevesService)
        {
            _elevesService = elevesService;
        }
    }
}