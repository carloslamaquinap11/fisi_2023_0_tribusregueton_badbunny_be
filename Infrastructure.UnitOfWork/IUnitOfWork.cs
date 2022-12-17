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
        public IDentistaRepository DentistaRepository { get; }
        public IFacturaRepository FacturaRepository { get; }
        public IPacienteRepository PacienteRepository { get; }
        public IServicioRepository ServicioRepository { get; }
        public IServicioCitaRepository ServicioCitaRepository { get; }
        public void Commit();
    }
}
