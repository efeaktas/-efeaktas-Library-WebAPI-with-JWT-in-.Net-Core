using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DTO.Type;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class TypeController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Update(int id, string name)
        {
            ListTypeResponse response = new ListTypeResponse();
            response.Id = id;
            response.Name = name;
            return View(response);
        }

    }
}
