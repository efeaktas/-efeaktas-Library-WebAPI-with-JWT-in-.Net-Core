using Library.Business.Factory;
using Library.Business.IServiceRepository;
using Library.Business.Repository;
using Library.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Business.ServiceRepository
{
    public class TypeRepository : Repository<Type>,ITypeRepository
    {
        public TypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<Type> ListActiveOnes()
        {
            return _dbContext.Type.Where(e => e.IsActive == true).ToList();
        }
    }
}
