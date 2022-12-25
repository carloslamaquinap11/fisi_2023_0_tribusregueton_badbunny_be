using Domain.Entity;
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
        [HttpGet("{id}")]
        public Paciente GetPaciente(int id)
        {
            var paciente = unitOfWork.PacienteRepository.GetById(id);
            return paciente;
        }

        [HttpGet("LogIn")]
        public Paciente LogIn(string email,string contrasena)
        {
            var paciente = new Paciente { Email = email, Contrasena = contrasena };
            var resultado = unitOfWork.PacienteRepository.LogIn(paciente);
            return resultado;
        }

        [HttpPost]
        public int InsertPaciente(Paciente paciente)
        {
            var resultado = unitOfWork.PacienteRepository.Insert(paciente);
            return resultado;
        }
        [HttpPut]
        public int UpdatePaciente(Paciente paciente)
        {
            var resultado = unitOfWork.PacienteRepository.Update(paciente);
            return resultado;
        }
        [HttpDelete("{id}")]
        public int DeletePaciente(int id)
        {
            var resultado = unitOfWork.PacienteRepository.DeleteById(id);
            return resultado;
        }
    }
}
