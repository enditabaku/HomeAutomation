using HomeApp.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeApp.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository repository;
        public HomeController(IUserRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LivingRoom()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                return View("LivingRoom");
            }
            return View("PublicLivingRoom");
        }

        public ActionResult Kitchen()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Kitchen");
            }
            return View("PublicKitchen");
        }

        public ActionResult BedRoom()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Bedroom");
            }
            return View("PublicBedroom");
        }

        public ActionResult BathRoom()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Bathroom");
            }
            return View("PublicBathRoom");
        }

        public ActionResult Studio()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Studio");
            }
            return View("PublicStudio");
        }
        public ActionResult Lights()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Lights");
            }
            return View("PublicLights");
        }

        public ActionResult Doors()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Doors");
            }
            return View("PublicDoors");
        }
    }
}