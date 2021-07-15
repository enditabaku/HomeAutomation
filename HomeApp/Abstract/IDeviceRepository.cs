using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Abstract
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> Devices { get; }
    }
}
