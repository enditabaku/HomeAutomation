using HomeApp.Abstract;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApp.Concrete
{
    public class DeviceRepository : IDeviceRepository
    {
        public HomeContext context = new HomeContext();
        public IEnumerable<Device> Devices
        {
            get
            {
                return context.Devices;
            }
        }
    }
}