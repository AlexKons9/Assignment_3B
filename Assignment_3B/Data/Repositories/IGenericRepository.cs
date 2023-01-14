using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3B.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void AddOrUpdate(T entity);
        bool Remove(int id);
    }
}