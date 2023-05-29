using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Web.ViewModels
{
	public class SignupViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
		[Display(Name = "Username :")]
		public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        [Display(Name = "Email :")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required!")]
        [Display(Name = "Phone :")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password :")]
        public string? Password { get; set; }
        [Compare(nameof(Password))]
        [Display(Name = "Password Confirm :")]
        public string? PasswordConfirm { get; set; }

	}
}

