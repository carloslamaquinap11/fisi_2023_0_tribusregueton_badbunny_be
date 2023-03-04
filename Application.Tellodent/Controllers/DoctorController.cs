using Domain.Entity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public DoctorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public Doctor GetDoctor(int id)
        {
            var doctor1 = unitOfWork.DoctorRepository.GetById(id);
            return doctor1;
        }

        //[HttpGet]
        //public IActionResult AllDentistas()
        //{
        //    var dentista = unitOfWork.DoctorRepository.GetAll();
        //    return Ok(dentista);
        //}

        //[HttpGet("LogIn")]
        //public IActionResult LogIn(string email, string contrasena)
        //{
        //    var dentista = new Doctor { Email = email, Contrasena = contrasena };
        //    var resultado = unitOfWork.DoctorRepository.LogIn(dentista);
        //    return Ok(resultado);
        //}
    }
}
