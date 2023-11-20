using System;
using System.ComponentModel.DataAnnotations;

namespace CourseTask.Src.ViewModels
{
	public class CourseUserViewModel
    {
        [Required(ErrorMessage = "CourseIds list is required.")]
        [MinLength(1, ErrorMessage = "At least one course ID is required.")]
        public List<int> CourseIds { get; set; }
	}
}

