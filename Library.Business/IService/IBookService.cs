using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.IService
{
    public interface IBookService
    {
        void Add(Book book);
        Task<List<Book>> ListActiveOnes();
        Task<Book> GetById(int id);
        void Update(Book book);
    }
}
