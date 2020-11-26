using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.IService
{
    public interface IAuthorService
    {
        void Add(Author author);
        List<Author> ListActiveOnes();
        Task<Author> GetById(int id);
        void Update(Author author);
    }
}
