using Infrastructure.Repository.IRepository;
using Infrastructure.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellodent.Helpers;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction transaction;
        private IDbConnection connection;
        private IClienteRepository clienteRepository;
        private IServicioCitaRepository servicioCitaRepository;
        private IServicioRepository servicioRepository;
        private ICitaRepository citaRepository;
        private IDoctorRepository doctorRepository;

        public IDoctorRepository DoctorRepository
        {
            get
            {
                return doctorRepository ?? (doctorRepository = new DoctorRepository(transaction));
            }
        }
        public ICitaRepository CitaRepository
        {
            get
            {
                return citaRepository ?? (citaRepository = new CitaRepository(transaction));
            }
        }
        
        public IServicioRepository ServicioRepository
        {
            get
            {
                return servicioRepository ?? (servicioRepository = new ServicioRepository(transaction));
            }
        }

        public IServicioCitaRepository ServicioCitaRepository
        {
            get
            {
                return servicioCitaRepository ?? (servicioCitaRepository = new ServicioCitaRepository(transaction));
            }
        }

        public UnitOfWork()
        {
            connection = new SqlConnection(new Settings().connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return clienteRepository ?? (clienteRepository = new ClienteRepository(transaction));
            }
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                transaction = connection.BeginTransaction();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
