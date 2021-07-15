using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You must enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="You must enter a password")]
        public string Password { get; set; }
        [Compare("Password")]
        [Required(ErrorMessage ="Your passwords don't match.")]
        public string ConfirmPassword { get; set; }
        public string RelationToOwner { get; set; }
    }
}