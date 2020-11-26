using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Factory
{
    public class DbFactory : IDbFactory, IDisposable
    {
        protected LibraryDbContext _dbContext;

        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }

        public LibraryDbContext Init()
        {

            return _dbContext ?? (_dbContext = new LibraryDbContext());
        }
    }
}
