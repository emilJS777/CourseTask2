using System;
using CourseTask.Src.Models;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src.Services
{
	public interface ICourseService
	{
		bool? Create(CourseViewModel courseViewModel);
        bool? Update(int id, CourseViewModel courseViewModel);
        bool? Delete(int id);
        CourseModel? Get(int id);
        List<CourseModel> Get();
    }
}

