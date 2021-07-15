using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApp.Models
{
    public class Light
    {
        [Key]
        public int Id { get; set; }
        public string Room { get; set; }
        public string Type { get; set; }
        public bool State { get; set; }
    }
}