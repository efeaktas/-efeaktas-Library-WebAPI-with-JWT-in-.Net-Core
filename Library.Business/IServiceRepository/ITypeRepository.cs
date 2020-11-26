using Library.Business.Repository;
using Library.DataAccess;
using System.Collections.Generic;


namespace Library.Business.IServiceRepository
{
    public interface ITypeRepository :IRepository<Type>
    {
        List<Type> ListActiveOnes();
    }
}
