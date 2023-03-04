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
    public class CitaRepository:GenericRepository<Cita>, ICitaRepository
    {
        public CitaRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public Cita ProximaCita(int idCliente)
        {
            var linq = Connection.Query("MostrarCitaActualCliente @ClienteId", new { @ClienteId = idCliente }, Transaction).ToList();

            if (linq.Count > 0)
            {
                return linq.FirstOrDefault();
            }
            return null;
        }
    }
}
