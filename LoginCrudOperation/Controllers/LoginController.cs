using LoginCrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginCrudOperation.Controllers
{
    public class LoginController : Controller
    {
        LoginContext _db = new LoginContext();
        public IActionResult Index()
        {
            return View(_db.GetUserLogins());
        }

        public IActionResult CreateUserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUserLogin(LoginModel loginuser)
        {
            int result = _db.SaveUserLogin(loginuser);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
