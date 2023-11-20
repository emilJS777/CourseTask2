using System;
using CourseTask.Src.Models;

namespace CourseTask.Src.Repositories
{
	public interface ICourseRepository
	{
		void Create(CourseModel courseModel);
        void Update(CourseModel courseModel);
        void Delete(CourseModel courseModel);
        CourseModel? Get(int id);
        CourseModel? Get(string title);
        CourseModel? GetByTitleExcludeId(string title, int id);
        List<CourseModel> Get(List<int> ids);
        List<CourseModel> Get();
    }
}

