using System;
using CourseTask.Src.Repositories;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src.Services
{
	public class CourseUserService : ICourseUserService
	{
        private readonly ICourseRepository courseRepository;
        private readonly IUserRepository userRepository;
        public CourseUserService(ICourseRepository courseRepository, IUserRepository userRepository)
		{
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
		}

        public bool? Bind(int userId, CourseUserViewModel courseUserViewModel)
        {
            var user = userRepository.Get(userId);
            if (user == null)
                return null;
            var courses = courseRepository.Get(courseUserViewModel.CourseIds);
            user.Courses.AddRange(courses);
            userRepository.Update(user);
            return true;
        }

        public bool? Unbind(int userId, CourseUserViewModel courseUserViewModel)
        {
            var user = userRepository.Get(userId);
            if (user == null)
                return null;
            var courses = courseRepository.Get(courseUserViewModel.CourseIds);
            user.Courses.RemoveAll(c => courses.Contains(c));
            userRepository.Update(user);
            return true;
        }
    }
}

