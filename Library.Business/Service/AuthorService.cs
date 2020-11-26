using Library.Business.IService;
using Library.Business.IServiceRepository;
using Library.Business.UnitOfWork;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Service
{
    public class AuthorService:IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IAuthorRepository authorRepository,IUnitOfWork unitOfWork)
        {
            this._authorRepository = authorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Author author)
        {
            _authorRepository.Add(author);
            _unitOfWork.SaveChanges();
        }

        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }

        public List<Author> ListActiveOnes()
        {
            return _authorRepository.ListActiveOnes();
        }

        public void Update(Author author)
        {
           _authorRepository.Update(author);
            _unitOfWork.SaveChanges();
        }
    }
}
