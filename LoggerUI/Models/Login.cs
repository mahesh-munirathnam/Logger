using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoggerPortal.Models
{
    public class Login
    {

        [Required]
        [StringLength(254)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}