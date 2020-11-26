using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [Route("UserCreate")]
        public async Task<IActionResult> UserCreate()
        {
            //Test User Oluşturulması
            AppUser user = new AppUser();
            user.Email = "test@gmail.com";
            user.UserName = "test@gmail.com";
            IdentityResult result = await _userManager.CreateAsync(user, "1");
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("NormalUser").Result)
                {
                    AppRole role = new AppRole()
                    {
                        Name = "NormalUser"
                    };
                    IdentityResult roleResult = await _roleManager.CreateAsync(role);
                    if (roleResult.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    }
                }             
            }
            return View();
        }
    }
}
