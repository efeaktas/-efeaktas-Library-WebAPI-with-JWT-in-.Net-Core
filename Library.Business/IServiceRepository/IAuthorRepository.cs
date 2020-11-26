using Library.Business.Repository;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.IServiceRepository
{
    public interface IAuthorRepository:IRepository<Author>
    {
        List<Author>ListActiveOnes();
    }
}
