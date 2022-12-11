using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        public IPacienteRepository PacienteRepository { get; }
        public void Commit();
    }
}
