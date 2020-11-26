using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
