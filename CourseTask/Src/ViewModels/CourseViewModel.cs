using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CourseTask.Src.ViewModels
{
	public class CourseViewModel
	{
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

