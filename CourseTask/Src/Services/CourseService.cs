using System;
using AutoMapper;
using CourseTask.Src.Models;
using CourseTask.Src.Repositories;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src.Services
{
	public class CourseService : ICourseService
	{
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;
		public CourseService(ICourseRepository courseRepository, IMapper mapper)
		{
            this.courseRepository = courseRepository;
            this.mapper = mapper;
		}

        public bool? Create(CourseViewModel courseViewModel)
        {
            var course = courseRepository.Get(courseViewModel.Title);
            if (course != null)
                return false;

            courseRepository.Create(mapper.Map<CourseModel>(courseViewModel));
            return true;
        }

        public bool? Delete(int id)
        {
            var course = courseRepository.Get(id);
            if (course == null)
                return null;
            courseRepository.Delete(course);
            return true;
        }

        public CourseModel? Get(int id)
        {
            var course = courseRepository.Get(id);
            if (course == null)
                return null;
            return course;
        }

        public List<CourseModel> Get()
        {
            List<CourseModel> courses = courseRepository.Get();
            return courses;
        }

        public bool? Update(int id, CourseViewModel courseViewModel)
        {
            var course = courseRepository.Get(id);
            if (course == null)
                return null;
            if (courseRepository.GetByTitleExcludeId(courseViewModel.Title, id) != null)
                return false;
            courseRepository.Update(mapper.Map(courseViewModel, course));
            return true;
        }
    }
}

