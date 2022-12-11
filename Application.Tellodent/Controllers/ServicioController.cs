using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ServicioController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllServicios()
        {
            var servicios = unitOfWork.ServicioRepository.GetAll();
            return Ok(servicios);
        }
    }
}
