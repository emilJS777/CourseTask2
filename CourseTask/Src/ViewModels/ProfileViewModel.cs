using System;
using System.ComponentModel.DataAnnotations;

namespace CourseTask.Src.ViewModels
{
	public class ProfileViewModel
	{
        [MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string LastName { get; set; }

        [RegularExpression(@"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$", ErrorMessage = "Date of birth must be in the format MM/DD/YYYY")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "The Phone Number must be in the format (999) 999-9999.")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}

