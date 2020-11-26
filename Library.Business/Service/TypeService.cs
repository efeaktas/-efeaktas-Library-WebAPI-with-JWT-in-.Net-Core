using Library.Business.IService;
using Library.Business.IServiceRepository;
using Library.Business.UnitOfWork;
using Library.DataAccess;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Service
{
   public  class TypeService :ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TypeService(ITypeRepository typeRepository,IUnitOfWork unitOfWork)
        {
            this._typeRepository = typeRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Type type)
        {
            _typeRepository.Add(type);
            _unitOfWork.SaveChanges();
        }

        public async Task<Type> GetById(int id)
        {
            return await _typeRepository.GetById(id);
        }

        public List<Type> ListActiveOnes()
        {
            return _typeRepository.ListActiveOnes();
        }

        public void Update(Type type)
        {
            _typeRepository.Update(type);
            _unitOfWork.SaveChanges();
        }
    }
}
