using Application.Tellodent.ViewModel;
using Domain.Entity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("GetCita/{id}")]
        public Cita GetCita(int id)
        {
            var cita1 = unitOfWork.CitaRepository.GetById(id);
            return cita1;
        }

        [HttpGet("GetProximaCita/{id}")]
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

        [HttpGet("GetCitaByClienteId/{id}")]
        public IActionResult GetCitaByClienteId(int id)
        {
            
            var listaCitaViewModel = new List<CitaViewModel>();

            var citasCliente = unitOfWork.CitaRepository.GetAll();
            if (citasCliente!=null)
            {
                citasCliente = citasCliente.Where(x => x.ClienteId == id).ToList();
                foreach (var cita in citasCliente)
                {
                    var repoServicioCita = unitOfWork.ServicioCitaRepository.GetAll();
                    if (repoServicioCita!=null)
                    {
                        var servicioCita = repoServicioCita.Where(x => x.CitaId == cita.CitaId).FirstOrDefault();
                        var servicio = unitOfWork.ServicioRepository.GetAll().Where(x=>x.ServicioId==servicioCita.ServicioId).FirstOrDefault();

                        var citaViewModel = new CitaViewModel();
                        citaViewModel.CitaId=cita.CitaId;
                        citaViewModel.NombreDoctor = cita.NombreDoctor;
                        citaViewModel.FechaCita = string.Format("{0}:dd/MM/yyyy", cita.FechaCita);
                        citaViewModel.HoraCita = cita.HoraCita.ToString();
                        citaViewModel.Observacion = "Sin observación";
                        citaViewModel.NombreServicio = servicio.Nombre;

                        listaCitaViewModel.Add(citaViewModel);
                    }

                }



            }

            return Ok(listaCitaViewModel);
        }
    }
}
