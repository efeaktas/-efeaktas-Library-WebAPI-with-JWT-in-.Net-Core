
using Library.DataAccess;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.IService
{
    public interface ITypeService
    {
        void Add(Type type);
        List<Type> ListActiveOnes();
        Task<Type> GetById(int id);
        void Update(Type type);
    }
}
