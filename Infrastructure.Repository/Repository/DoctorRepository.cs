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
    public class DoctorRepository:GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        //public Dentista LogIn(Dentista dentista)
        //{
        //    var linq = Connection.Query<Dentista>("SELECT * FROM Dentista WHERE Email=@Email AND Contrasena=@Contrasena", new { @Email = dentista.Email, @Contrasena = dentista.Contrasena }, Transaction).ToList();
        //    if (linq.Count > 0)
        //    {
        //        return linq.FirstOrDefault();
        //    }
        //    return null;
            
        //}

        public Doctor LogIn(Doctor dentista)
        {
            throw new NotImplementedException();
        }
    }
}
