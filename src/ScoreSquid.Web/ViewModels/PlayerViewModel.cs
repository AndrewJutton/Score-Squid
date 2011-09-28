using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.ViewModels
{
    public class PlayerViewModel
    {
        [Required(ErrorMessage = "Required field"), Email, StringLength(60, ErrorMessage = "Max 60 chars")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 chars")]
        public string Password { get; set; }

        [Required]
        [EqualTo("Password")]
        [NotMapped]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Required field"), StringLength(40, ErrorMessage = "Max 40 chars")]
        public string Forename { get; set; }

        [Required(ErrorMessage = "Required field"), StringLength(40, ErrorMessage = "Max 40 chars")]
        public string Surname { get; set; }
    }
}