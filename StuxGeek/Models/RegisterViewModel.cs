using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StuxGeek.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        
        [Required]
        [Compare("Email")]
        [DisplayName("Repeat Email")]
        public string C_Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DisplayName("Repeat Password")]
        public string C_Password { get; set; }

        [Required]
        public DateTime TimeOfRegistration { get; set; }
    }
}