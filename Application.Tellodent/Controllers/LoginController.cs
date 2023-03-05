using Domain.Entity;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Application.Tellodent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public LoginController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public Login GetLogin(int id)
        {
            var login = unitOfWork.LoginRepository.GetById(id);
            return login;
        }

        [HttpGet("SignIn")]
        public IActionResult SignIn(string email,string pass)
        {
            var Login = new Login { Email = email,Password = pass};
            var resultado = unitOfWork.LoginRepository.SignIn(Login);
            return Ok(resultado);
        }


        [HttpPost]
        public int InsertLogin(Login login)
        {
            var resultado = unitOfWork.LoginRepository.Insert(login);
            return resultado;
        }
    }
}