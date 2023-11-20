using System;
using CourseTask.Src.Models;

namespace CourseTask.Src.ViewModels
{
	public class UserViewModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public ProfileViewModel Profile { get; set; }
		public List<CourseModel> Courses { get; set; }
	}
}

