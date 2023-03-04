using Domain.Entity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public CitaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AllCitas()
        {
            var cita = unitOfWork.CitaRepository.GetAll();
            return Ok(cita);
        }

        [HttpGet("{id}")]
        public Cita GetCita(int id)
        {
            var cita1 = unitOfWork.CitaRepository.GetById(id);
            return cita1;
        }

        [HttpGet("{id}")]
        public Cita GetProximaCita(int idCliente)
        {
            var cita1 = unitOfWork.CitaRepository.ProximaCita(idCliente);
            return cita1;
        }

        [HttpPost]
        public IActionResult InsertCita(Cita cita)
        {
            cita.Estado = (int) KDAppointmentState.PORATENDER;
            var citaux = unitOfWork.CitaRepository.Insert(cita);
            unitOfWork.Commit();
            return Ok(citaux);
        }

        [HttpPut]
        public IActionResult CancelarCita(Cita cita)
        {
            cita.Estado = (int)KDAppointmentState.CANCELADO;
            var citaux = unitOfWork.CitaRepository.Update(cita);
            unitOfWork.Commit();
            return Ok(citaux);
        }


    }
}
