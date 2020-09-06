using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationForm.Models
{
    [MetadataType(typeof(Studentmetadata))]
    public partial class User2
    {
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    public  class Studentmetadata
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Fiend mandatory")]
        [Remote("Isusernamealready", "User2",ErrorMessage ="username already exist")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Fiend mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Fiend mandatory")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Mno { get; set; }

        [Required(ErrorMessage = "Fiend mandatory")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fiend mandatory")]
        public string State { get; set; }

        [Required(ErrorMessage = "Fiend mandatory")]
        public string City { get; set; }
    }
}