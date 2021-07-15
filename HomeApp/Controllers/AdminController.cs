using HomeApp.Abstract;
using HomeApp.Concrete;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        #region Fields
        HomeContext context = new HomeContext();
        private IUserRepository userrepo;
        private ILightRepository lightrepo;
        private IDoorRepository doorrepo;
        private IDeviceRepository devicerepo;
        #endregion
        #region Constructor
        public AdminController(IUserRepository ur, ILightRepository lr, IDoorRepository dr, IDeviceRepository dvr)
        {
            userrepo = ur;
            lightrepo = lr;
            doorrepo = dr;
            devicerepo = dvr;
        }
        #endregion
        public ViewResult Index()
        {
            return View();
        }
        #region Home
        public ActionResult AdminLivingRoom()
        {
            return View();
        }

        public ActionResult AdminKitchen()
        {
            return View();
        }

        public ActionResult AdminBedRoom()
        {
            return View();
        }

        public ActionResult AdminBathRoom()
        {
            return View();
        }

        public ActionResult AdminStudio()
        {
            return View();
        }
        public ActionResult AdminLights()
        {
            return View();
        }

        public ActionResult AdminDoors()
        {
            return View();
        }
        #endregion
        #region Users
        public ActionResult UserIndex()
        {
            return View(userrepo.Users.ToList());
        }
        public ViewResult EditUser(int userId)
        {
            User user = userrepo.Users.Where(u => u.Id == userId).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id == 0)
                {
                 context.Users.Add(user);
                }
                else
                {
                    User dbEntry = context.Users.Find(user.Id);
                    dbEntry.Id = user.Id;
                    dbEntry.ConfirmPassword = user.ConfirmPassword;
                    dbEntry.Name = user.Name;
                    dbEntry.Password = user.Password;
                    dbEntry.RelationToOwner = user.RelationToOwner;
                }
                context.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            return View();
        }
        public ViewResult CreateUser()
        {
            return View("EditUser", new User());
        }
        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            User deletedUser = context.Users.Find(userId);
            if (deletedUser != null)
            {
                context.Users.Remove(deletedUser);
                context.SaveChanges();
            }
            return RedirectToAction("UserIndex");
        }
        #endregion
        #region Lights
        public ActionResult LightIndex()
        {
            return View(lightrepo.Lights.ToList());
        }
        public ViewResult EditLight(int Id)
        {
            Light light = lightrepo.Lights.Where(l => l.Id == Id).FirstOrDefault();
            return View(light);
        }
        [HttpPost]
        public ActionResult EditLight(Light light)
        {
            if (ModelState.IsValid)
            {
                if(light.Id == 0)
                {
                    context.Lights.Add(light);
                }
                else
                {
                    Light dbEntry = context.Lights.Find(light.Id);
                    dbEntry.Id = light.Id;
                    dbEntry.Room = light.Room;
                    dbEntry.State = light.State;
                    dbEntry.Type = light.Type;
                }
                context.SaveChanges();
                return RedirectToAction("LightIndex");
            }
            return View();
        }
        public ViewResult CreateLight()
        {
            return View("EditLight", new Light());
        }
        [HttpPost]
        public ActionResult DeleteLight(int Id)
        {
            Light deletedLight = context.Lights.Find(Id);
            if (deletedLight != null)
            {
                context.Lights.Remove(deletedLight);
                context.SaveChanges();
            }
            return RedirectToAction("LightIndex");
        }
        #endregion
        #region Doors
        public ActionResult DoorIndex()
        {
            return View(doorrepo.Doors.ToList());
        }
        public ViewResult EditDoor(int Id)
        {
            Door door = doorrepo.Doors.Where(d => d.Id == Id).FirstOrDefault();
            return View(door);
        }
        [HttpPost]
        public ActionResult EditDoor(Door door)
        {
            if (ModelState.IsValid)
            {
                if (door.Id == 0)
                {
                    context.Doors.Add(door);
                }
                else
                {
                    Door dbEntry = context.Doors.Find(door.Id);
                    dbEntry.Id = door.Id;
                    dbEntry.Name = door.Name;
                    dbEntry.State = door.State;
                }
                context.SaveChanges();
                return RedirectToAction("DoorIndex");
            }
            return View();
        }
        public ViewResult CreateDoor()
        {
            return View("EditDoor", new Door());
        }
        [HttpPost]
        public ActionResult DeleteDoor(int Id)
        {
            Door deletedDoor = context.Doors.Find(Id);
            if (deletedDoor != null)
            {
                context.Doors.Remove(deletedDoor);
                context.SaveChanges();
            }
            return RedirectToAction("DoorIndex");
        }
        #endregion
        #region Devices
        public ActionResult DeviceIndex()
        {
            return View(devicerepo.Devices.ToList());
        }
        public ViewResult EditDevice(int Id)
        {
            Device device = devicerepo.Devices.Where(d => d.Id == Id).FirstOrDefault();
            return View(device);
        }
        [HttpPost]
        public ActionResult EditDevice(Device device)
        {
            if (ModelState.IsValid)
            {
                if (device.Id == 0)
                {
                    context.Devices.Add(device);
                }
                else
                {
                    Device dbEntry = context.Devices.Find(device.Id);
                    dbEntry.Id = device.Id;
                    dbEntry.Name = device.Name;
                    dbEntry.Room = device.Room;
                    dbEntry.State = device.State;
                }
                context.SaveChanges();
                return RedirectToAction("DeviceIndex");
            }
            return View();
        }
        public ViewResult CreateDevice()
        {
            return View("EditDevice", new Device());
        }
        [HttpPost]
        public ActionResult DeleteDevice(int Id)
        {
            Device deletedDevice = context.Devices.Find(Id);
            if (deletedDevice != null)
            {
                context.Devices.Remove(deletedDevice);
                context.SaveChanges();
            }
            return RedirectToAction("DeviceIndex");
        }
        #endregion
    }
}