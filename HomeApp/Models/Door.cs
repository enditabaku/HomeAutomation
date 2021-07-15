using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApp.Models
{
    public class Door
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}