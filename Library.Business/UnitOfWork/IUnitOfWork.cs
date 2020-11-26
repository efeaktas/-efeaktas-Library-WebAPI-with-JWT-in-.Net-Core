using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
