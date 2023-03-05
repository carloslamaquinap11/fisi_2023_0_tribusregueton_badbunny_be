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
        public ICitaRepository CitaRepository { get; }
        public IDoctorRepository DoctorRepository { get; }

        public IClienteRepository ClienteRepository { get; }
        public IServicioRepository ServicioRepository { get; }
        public IServicioCitaRepository ServicioCitaRepository { get; }
        public ILoginRepository LoginRepository { get; }
        public void Commit();
    }
}
