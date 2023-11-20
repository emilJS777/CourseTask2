using System;
using AutoMapper;
using CourseTask.Src.Models;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
            CreateMap<RegistrationViewModel, UserModel>().ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassword(src.Password)));
            CreateMap<ProfileViewModel, ProfileModel>();
            CreateMap<ProfileModel, ProfileViewModel>();
            CreateMap<UserModel, UserViewModel>();
            CreateMap<UserViewModel, UserModel>();

            CreateMap<CourseModel, CourseViewModel>();
            CreateMap<CourseViewModel, CourseModel>();

        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

