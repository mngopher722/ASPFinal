using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPFinal.Models
{
    public class Contact
    {
        [Required]
        public BRANCH Location { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        public string comments { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email")]
        [Display(Name = "Confirm Email Address")]
        public string confirmEmail { get; set; }
    }
}