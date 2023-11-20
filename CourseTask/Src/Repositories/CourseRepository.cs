using System;
using CourseTask.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseTask.Src.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private readonly ApplicationDbContext dbContext;
		public CourseRepository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

        public void Create(CourseModel courseModel)
        {
            dbContext.Courses.Add(courseModel);
            dbContext.SaveChanges();
        }

        public void Delete(CourseModel courseModel)
        {
            dbContext.Courses.Remove(courseModel);
            dbContext.SaveChanges();
        }

        public CourseModel? Get(int id)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
            return course;
        }

        public CourseModel? Get(string title)
        {
            var course = dbContext.Courses.FirstOrDefault(c => c.Title == title);
            return course;
        }

        public List<CourseModel> Get()
        {
            var courses = dbContext.Courses.ToList();
            return courses;
        }

        public List<CourseModel> Get(List<int> ids)
        {
            var courses = dbContext.Courses.Where(c => ids.Contains(c.Id)).ToList();
            return courses;
        }

        public CourseModel? GetByTitleExcludeId(string title, int id)
        {
            var course = dbContext.Courses.Where(c => c.Title == title && c.Id != id).FirstOrDefault();
            return course;
        }

        public void Update(CourseModel courseModel)
        {
            dbContext.Courses.Update(courseModel);
            dbContext.SaveChanges();
        }
    }
}

