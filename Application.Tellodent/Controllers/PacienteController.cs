using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public PacienteController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllPacientes()
        {
            var pacientes = unitOfWork.PacienteRepository.GetAll();
            return Ok(pacientes);
        }
    }
}
