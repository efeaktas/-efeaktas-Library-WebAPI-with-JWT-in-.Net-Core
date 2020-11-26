using Library.Business.Factory;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryDbContext _dbContext;
        private IDbFactory _dbFactory;
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbContext = this._dbFactory.Init();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
