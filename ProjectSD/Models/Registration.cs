using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectSD.Models
{
    public class Registration
    {
        public int ID { get; set; }

        [Required]
        [Display(Name="Username")]
        [DataType(DataType.EmailAddress)]
        public String Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
    }
}