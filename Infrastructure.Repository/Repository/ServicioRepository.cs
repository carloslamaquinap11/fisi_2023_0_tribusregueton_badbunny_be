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
    public class ServicioRepository:GenericRepository<Servicio>, IServicioRepository
    {
        public ServicioRepository(IDbTransaction transaction) : base(transaction)
        {

        }
    }
}
