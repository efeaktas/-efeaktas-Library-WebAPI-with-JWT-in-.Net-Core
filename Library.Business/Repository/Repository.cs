using Library.Business.Factory;
using Library.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected LibraryDbContext _dbContext; 
        private IDbFactory _dbFactory;  
        private DbSet<T> _dbSet;
        public Repository(IDbFactory dbFactory)
        {

            _dbFactory = dbFactory;
            _dbContext = this._dbFactory.Init();
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
             _dbSet.AddAsync(entity);
        }

        public bool Delete(T entity)
        {
            this.Update(entity);
            return true;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
