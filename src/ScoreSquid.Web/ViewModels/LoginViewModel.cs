using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace ScoreSquid.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "Max 60 chars")]
        [Email]
        [Display(Name = "Email Address")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 chars")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}