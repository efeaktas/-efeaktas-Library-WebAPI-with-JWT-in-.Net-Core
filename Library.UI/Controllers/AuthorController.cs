using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DTO.Author;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class AuthorController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Update(int id,string name)
        {
            ListAuthorResponse response = new ListAuthorResponse();
            response.Id = id;
            response.Name = name;
            return View(response);
        }
    }
}
