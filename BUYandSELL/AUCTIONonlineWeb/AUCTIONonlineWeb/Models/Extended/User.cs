using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AUCTIONonlineWeb.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public string confirmPassword { get; set; }
       
    }

    public class UserMetadata
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public string Address { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "State Required")]
        public string State { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "Identity Required")]
        [Display(Name ="Aadhar Number")]
        public string Identity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string confirmPassword { get; set; }

        


    }


   
}