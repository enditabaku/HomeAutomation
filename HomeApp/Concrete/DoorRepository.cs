using HomeApp.Abstract;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApp.Concrete
{
    public class DoorRepository : IDoorRepository
    {
        public HomeContext context = new HomeContext();
        public IEnumerable<Door> Doors
        {
            get
            {
                return context.Doors;
            }
        }
       
    }
}