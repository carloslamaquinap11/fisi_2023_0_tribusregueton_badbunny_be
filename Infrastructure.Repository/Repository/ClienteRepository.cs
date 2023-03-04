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
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IDbTransaction transaction) : base(transaction)
        {

        }
        public Cliente LogIn(Cliente cliente)
        {
            var linq = Connection.Query<Cliente>("SELECT * FROM Paciente WHERE ClienteId = @ClienteId", new { @ClienteId = cliente.ClienteId},Transaction).ToList();

            if (linq.Count > 0)
            {
                return linq.FirstOrDefault();
            }
            return null;
        }
    }
}
