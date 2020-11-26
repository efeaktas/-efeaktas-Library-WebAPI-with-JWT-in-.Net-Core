using Library.Business.Repository;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.IServiceRepository
{
    public interface IBookRepository :IRepository<Book>
    {
        Task<List<Book>> ListActiveOnes();
    }
}
