using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        int Insert(T entity);
        T GetById(int id);
        int Update(T entity);
        int DeleteById(int id);
    }
}
