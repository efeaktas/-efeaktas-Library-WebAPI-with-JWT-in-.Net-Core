using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    public class SettingsController : BaseController
    {
        public IActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "account"); ;
        }
    }
}
