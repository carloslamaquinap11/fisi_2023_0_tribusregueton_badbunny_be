using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public DentistaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllDentistas()
        {
            var dentista = unitOfWork.DentistaRepository.GetAll();
            return Ok(dentista);
        }
    }
}
