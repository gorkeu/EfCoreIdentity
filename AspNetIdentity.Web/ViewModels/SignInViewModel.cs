using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspNetIdentity.Web.ViewModels
{
	public class SignInViewModel
	{
        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        [Display(Name = "Email :")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password :")]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
	}
}

