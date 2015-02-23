using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectSD.Models
{
    public class Users
    {
        public int UsersID { set; get; }

        [Required]
        [Display(Name = "Username")]
        [DataType(DataType.EmailAddress)]
        public String Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public virtual ICollection<PersonalInfo> PersonalInfo { set; get; }
    }
}