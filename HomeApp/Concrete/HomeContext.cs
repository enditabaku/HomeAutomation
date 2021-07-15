using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeApp.Concrete
{
    public class HomeContext : DbContext
    {
        public HomeContext() : base("name=HomeContext") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Light> Lights { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}