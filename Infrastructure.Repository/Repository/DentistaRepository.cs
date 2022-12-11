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
    public class DentistaRepository:GenericRepository<Dentista>, IDentistaRepository
    {
        public DentistaRepository(IDbTransaction transaction) : base(transaction)
        {

        }
    }
}
