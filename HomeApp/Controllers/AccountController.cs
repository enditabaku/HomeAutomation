using HomeApp.Infrastructure;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeApp.Controllers
{
    public class AccountController : Controller
    {
        public IAuthProvider authProvider = new FormsAuthProvider();
        public AccountController()
        {
        }

        public ViewResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Username, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ViewBag.Message = "Incorrect username or password.";
                    return View();
                }
            }
            else { return View(model); }
        }
    }
}
