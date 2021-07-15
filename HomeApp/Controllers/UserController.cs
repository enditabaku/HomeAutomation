using HomeApp.Abstract;
using HomeApp.Concrete;
using HomeApp.Infrastructure;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeApp.Controllers
{
    public class UserController : Controller
    {
        HomeContext context = new HomeContext();
        IUserRepository repository = new UserRepository();
        IAuthProvider authProvider = new FormsAuthProvider();
        public UserController(IAuthProvider auth, IUserRepository repo)
        {
            authProvider = auth;
            repository = repo;
        }
        public UserController() { }
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.AuthenticateUser(model.Username, model.Password))
                {
                    User user = context.Users.Where(u => u.Name == model.Username).First();
                    TempData["testmsg"] = "You're now logged in.";
                    return Redirect(returnUrl ?? Url.Action("Index", "Home", user.Id));
                }
                else
                {
                    ViewBag.Message = "Wrong username or password.";
                }
            }
            return View(model);
        }

        public ViewResult Register()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = context.Users.Where(u => u.Name == user.Name).FirstOrDefault();
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "This username is not available.");
                    return View(user);
                }
                context.Users.Add(user);
                context.SaveChanges();
                if (authProvider.AuthenticateUser(user.Name, user.Password))
                {
                    return RedirectToAction("Index", "User", user.Id);
                }
                ViewBag.Message = "Your account was successfully created!";

            }
            else
            {
                ViewBag.Message = "Your account cannot be created.";
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie myCookie = new HttpCookie("cookieName");
            authProvider.SignOut();
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            return RedirectToAction("Index", "Home");
        }
    }
}

