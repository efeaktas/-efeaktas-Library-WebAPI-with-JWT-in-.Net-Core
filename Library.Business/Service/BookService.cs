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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IBookRepository bookRepository,IUnitOfWork unitOfWork)
        {
            this._bookRepository = bookRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
            _unitOfWork.SaveChanges();
        }

        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<List<Book>> ListActiveOnes()
        {
            return await _bookRepository.ListActiveOnes();
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
            _unitOfWork.SaveChanges();
        }
    }
}
