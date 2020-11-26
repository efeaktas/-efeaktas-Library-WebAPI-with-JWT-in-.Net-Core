using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DTO.Book;
using Library.DTO.Type;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class BookController : BaseController
    {
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int id,string name)
        {
            ListBookResponse response = new ListBookResponse();
            response.Id = id;
            response.BookName = name;
            return View(response);
        }
    }
}
