using Library.Business.Factory;
using Library.Business.IServiceRepository;
using Library.Business.Repository;
using Library.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.ServiceRepository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<List<Book>> ListActiveOnes()
        {
            return await _dbContext.Book.Where(e => e.IsActive == true).Include(a => a.Type).Include(b => b.Author).ToListAsync();
        }
    }
}
