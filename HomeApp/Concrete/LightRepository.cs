using HomeApp.Abstract;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApp.Concrete
{
    public class LightRepository : ILightRepository
    {
        public HomeContext context = new HomeContext();
        public IEnumerable<Light> Lights
        {
            get
            {
                return context.Lights;
            }
        }
    }
}