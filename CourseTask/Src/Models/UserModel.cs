using System;
using System.ComponentModel.DataAnnotations.Schema;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string PasswordHash { get; set; }

        [ForeignKey("Profile")]
        public int? ProfileId { get; set;}
		public ProfileModel? Profile { get; set; }

		public List<CourseModel> Courses { get; set; }
	}
}

