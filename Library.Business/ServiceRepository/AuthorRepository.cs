using Library.Business.Factory;
using Library.Business.IServiceRepository;
using Library.Business.Repository;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Business.ServiceRepository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<Author> ListActiveOnes()
        {
            return _dbContext.Author.Where(e => e.IsActive == true).ToList();
        }
    }
}
