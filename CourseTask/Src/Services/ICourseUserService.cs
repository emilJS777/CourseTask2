using System;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src.Services
{
	public interface ICourseUserService
	{
		bool? Bind(int userId, CourseUserViewModel courseUserViewModel);
        bool? Unbind(int userId, CourseUserViewModel courseUserViewModel);
    }
}

