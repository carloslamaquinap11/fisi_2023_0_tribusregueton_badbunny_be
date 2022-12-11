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

        private IPacienteRepository pacienteRepository;

        public UnitOfWork()
        {
            connection = new SqlConnection(new Settings().connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public IPacienteRepository PacienteRepository
        {
            get
            {
                return pacienteRepository ?? (pacienteRepository = new PacienteRepository(transaction));
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
