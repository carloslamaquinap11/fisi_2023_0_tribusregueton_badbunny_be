using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : class
    {
        public GenericRepository(IDbTransaction transaction) : base(transaction)
        {

        }
        public int DeleteById(int id)
        {
            return Connection.Delete<T>(id, transaction: Transaction);
        }

        public IEnumerable<T> GetAll()
        {
            return Connection.GetList<T>(null, transaction: Transaction);
        }

        public T GetById(int id)
        {
            return Connection.Get<T>(id, transaction: Transaction);
        }

        public virtual int Insert(T entity)
        {
            return (int)Connection.Insert(entity, transaction: Transaction);
        }

        public int Update(T entity)
        {
            return Connection.Update(entity, transaction: Transaction);
        }
    }
}
