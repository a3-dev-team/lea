
using A3.Lea.Cycle1.WebApi.Core.Eleves;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using Microsoft.AspNetCore.Mvc;

namespace A3.Lea.Cycle1.WebApi.Controllers
{
    [ApiController]
    [Route("api/lea/cycle1/v1/eleves")]
    public class ElevesController : ControllerBase
    {
        private readonly IElevesService _elevesService;

        [HttpGet(Name = "GetListeCarteIdentiteEleve")]
        public IEnumerable<CarteIdentiteEleve> Get()
        {
            return _elevesService.GetListeCarteIdentiteEleve(1);
        }

        public ElevesController(IElevesService elevesService)
        {
            _elevesService = elevesService;
        }
    }
}