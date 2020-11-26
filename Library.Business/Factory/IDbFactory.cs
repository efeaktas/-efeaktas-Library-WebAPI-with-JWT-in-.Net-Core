using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Factory
{
    public interface IDbFactory
    {
        LibraryDbContext Init();
    }
}
