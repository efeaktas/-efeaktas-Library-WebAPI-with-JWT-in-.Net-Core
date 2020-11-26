using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Business.IService;
using Library.DataAccess;
using Library.DTO.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookApiController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        [HttpPost]
        [Route("CreateBook")]
        public IActionResult CreateBook([FromBody]CreateBookRequest request)
        {
            Book book = new Book();
            book.Name = request.Name;
            book.AuthorId = request.AuthorId;
            book.TypeId = request.TypeId;
            book.IsActive = true;
            _bookService.Add(book);
            return Ok();
        }
        [HttpPost]
        [Route("ListBook")]
        public async Task<IActionResult> ListBook()
        {
            List<Book> books = await _bookService.ListActiveOnes();
            List<ListBookResponse> allResponses = new List<ListBookResponse>();
            foreach (Book book in books)
            {
                ListBookResponse response = new ListBookResponse();
                response.Id = book.Id;
                response.BookName = book.Name;
                response.AuthorId = book.AuthorId;
                response.AuthorName = book.Author.Name;
                response.TypeId = book.TypeId;
                response.TypeName = book.Type.Name;
                allResponses.Add(response);
            }
            return Ok(allResponses);
        }
        [HttpPost]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            Book book = await _bookService.GetById(request.Id);
            book.Name = request.Name;
            book.AuthorId = request.AuthorId;
            book.TypeId = request.TypeId;
            _bookService.Update(book);
            return Ok();
        }
        [HttpPost]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook([FromBody] DeleteBookRequest request)
        {
            Book book = await _bookService.GetById(request.Id);
            book.IsActive = false;
            _bookService.Update(book);
            return Ok();
        }

    }
}
