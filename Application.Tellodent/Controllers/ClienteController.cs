using Domain.Entity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ClienteController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllPacientes()
        {
            var pacientes = unitOfWork.ClienteRepository.GetAll();
            return Ok(pacientes);
        }
        [HttpGet("{id}")]
        public Cliente GetPaciente(int id)
        {
            var paciente = unitOfWork.ClienteRepository.GetById(id);
            return paciente;
        }

        [HttpGet("LogIn")]
        public IActionResult LogIn(int clienteId)
        {
            var paciente = new Cliente { ClienteId = clienteId};
            var resultado = unitOfWork.ClienteRepository.LogIn(paciente);
            return Ok(resultado);
        }

        [HttpPost]
        public int InsertPaciente(Cliente paciente)
        {
            var resultado = unitOfWork.ClienteRepository.Insert(paciente);
            return resultado;
        }
        [HttpPut]
        public int UpdatePaciente(Cliente paciente)
        {
            var resultado = unitOfWork.ClienteRepository.Update(paciente);
            return resultado;
        }
        [HttpDelete("{id}")]
        public int DeletePaciente(int id)
        {
            var resultado = unitOfWork.ClienteRepository.DeleteById(id);
            return resultado;
        }
    }
}
