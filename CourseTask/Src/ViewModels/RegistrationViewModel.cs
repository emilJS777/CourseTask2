using System;
using System.ComponentModel.DataAnnotations;

namespace CourseTask.Src.ViewModels
{
	public class RegistrationViewModel
	{
        [MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public ProfileViewModel Profile { get; set; }
	}
}

