using System;
using CourseTask.Src.Models;

namespace CourseTask.Src.Repositories
{
	public interface IUserRepository
	{
		void Create(UserModel userModel);
		void Update(UserModel userModel);
		void Delete(UserModel userModel);
		List<UserModel> Get();
		UserModel? Get(int id);
        UserModel? Get(string userName);
		UserModel? GetByNameExcludeId(string userName, int id);
    }
}

