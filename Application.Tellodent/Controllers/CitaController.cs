using Application.Tellodent.ViewModel;
using Domain.Entity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
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

        //[HttpPost("")]
        //public IActionResult InsertCita(Cita cita)
        //{
        //    cita.Estado = (int) KDAppointmentState.PORATENDER;
        //    var citaux = unitOfWork.CitaRepository.Insert(cita);
        //    unitOfWork.Commit();
        //    return Ok(citaux);
        //}

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
                citasCliente = citasCliente.Where(x => x.ClienteId == id).OrderByDescending(x=>x.CitaId).ToList();
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
                        citaViewModel.FechaCita = string.Format("{0}", cita.FechaCita);
                        citaViewModel.HoraCita = cita.HoraCita.ToString();
                        citaViewModel.Observacion = cita.Observacion;
                        citaViewModel.NombreServicio = servicio.Nombre;
                        citaViewModel.Especialidad = "Odontólogo";
                        citaViewModel.Direccion = cita.Local;

                        listaCitaViewModel.Add(citaViewModel);
                    }
                }
            }

            return Ok(listaCitaViewModel);
        }

        [HttpGet("GetCitaSiguiente/{id}")]
        public IActionResult GetCitaSiguiente(int id)
        {
            var listaCitaViewModel = new List<CitaViewModel>();

            var citasCliente = unitOfWork.CitaRepository.GetAll();
            if (citasCliente != null)
            {
                var citaUltima = citasCliente.Where(x => x.ClienteId == id && x.FechaCita > DateTime.Now).OrderBy(x=>x.CitaId).FirstOrDefault();
                //foreach (var cita in citasCliente)
                //{
                    var repoServicioCita = unitOfWork.ServicioCitaRepository.GetAll();
                    if (repoServicioCita != null)
                    {
                        var servicioCita = repoServicioCita.Where(x => x.CitaId == citaUltima.CitaId).FirstOrDefault();
                        var servicio = unitOfWork.ServicioRepository.GetAll().Where(x => x.ServicioId == servicioCita.ServicioId).FirstOrDefault();

                        var citaViewModel = new CitaViewModel();
                        citaViewModel.CitaId = citaUltima.CitaId;
                        citaViewModel.NombreDoctor = citaUltima.NombreDoctor;
                        citaViewModel.FechaCita = string.Format("{0}", citaUltima.FechaCita);
                        citaViewModel.HoraCita = citaUltima.HoraCita.ToString();
                        citaViewModel.Observacion = citaUltima.Observacion;
                        citaViewModel.NombreServicio = servicio.Nombre;
                        citaViewModel.Especialidad = "Odontólogo";
                        citaViewModel.Direccion = citaUltima.Local;

                        listaCitaViewModel.Add(citaViewModel);
                    }
                //}
            }
            return Ok(listaCitaViewModel);
        }

        [HttpPost]
        public IActionResult InsertCitaCompleta(InsertCitaViewModel insertcita)
        {
            var vardoct = unitOfWork.DoctorRepository.GetAll().Where(x=>x.DoctorId == insertcita.DoctorId).FirstOrDefault();
            var varpac = unitOfWork.ClienteRepository.GetAll().Where(x => x.ClienteId == insertcita.ClienteId).FirstOrDefault();
            var varserv = unitOfWork.ServicioRepository.GetAll().Where(x => x.ServicioId == insertcita.ServicioId).FirstOrDefault();

            var cita = new Cita()
            {
                DoctorId = insertcita.DoctorId,
                ClienteId = insertcita.ClienteId,
                NombreDoctor = vardoct.Nombres.ToString() + " " + vardoct.Apepat.ToString(),
                NombreCliente = varpac.Nombres.ToString() + " " + varpac.Apepat.ToString(),
                Observacion = insertcita.Observacion.ToString(),
                Motivo = insertcita.Motivo,
                FechaCita = Convert.ToDateTime(insertcita.FechaCita),
                HoraCita = insertcita.HoraCita,
                Local = insertcita.Local,
                PrecioInicial = varserv.Precio,
                Descuento = 0,
                PrecioFinal = varserv.Precio,
                Estado = 0,
                MotivoEstado = ""
            };

            var citaux = unitOfWork.CitaRepository.Insert(cita);
            unitOfWork.Commit();

            var serviciocita = new ServicioCita()
            {
                CitaId = citaux,
                ServicioId = insertcita.ServicioId,
                descripcion = varserv.Nombre,
                FechaServiciocita = Convert.ToDateTime(insertcita.FechaCita),
                PrecioServiciocita = varserv.Precio,
                Estado = 0,
            };

            var servicitaux = unitOfWork.ServicioCitaRepository.Insert(serviciocita);
            unitOfWork.Commit();

            return Ok(servicitaux);
        }
    }
}
