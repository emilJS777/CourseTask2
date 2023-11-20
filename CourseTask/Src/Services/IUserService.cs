using System;
using CourseTask.Src.ViewModels;

namespace CourseTask.Src.Services
{
	public interface IUserService
	{
		bool? Create(RegistrationViewModel registrationViewModel);
        string Login(LoginViewModel loginViewModel);
        bool? Update(int id, RegistrationViewModel registrationViewModel);
        bool? Delete(int id);
        UserViewModel? Get(int id);
        List<UserViewModel> Get();
    }
}

