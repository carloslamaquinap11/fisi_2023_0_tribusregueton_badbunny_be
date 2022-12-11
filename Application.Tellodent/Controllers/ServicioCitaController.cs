using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioCitaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ServicioCitaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllServicioCitas()
        {
            var serviciocitas = unitOfWork.ServicioCitaRepository.GetAll();
            return Ok(serviciocitas);
        }
    }
}
