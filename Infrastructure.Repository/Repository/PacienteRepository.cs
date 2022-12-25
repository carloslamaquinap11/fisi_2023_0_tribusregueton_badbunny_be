using Dapper;
using Domain.Entity;
using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repository
{
    public class PacienteRepository:GenericRepository<Paciente>,IPacienteRepository
    {
        public PacienteRepository(IDbTransaction transaction) : base(transaction)
        {

        }
        public Paciente LogIn(Paciente paciente)
        {
            var linq = Connection.Query<Paciente>("SELECT * FROM Paciente WHERE Email=@Email AND Contrasena=@Contrasena", new { @Email = paciente.Email, @Contrasena = paciente.Contrasena },Transaction).ToList();
            return linq.FirstOrDefault();
        }
    }
}
