using System;
using CourseTask.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseTask.Src.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly ApplicationDbContext _dbContext;
		public UserRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public void Create(UserModel userModel)
        {
            _dbContext.Users.Add(userModel);
            _dbContext.SaveChanges();
        }

        public void Delete(UserModel userModel)
        {
            _dbContext.Users.Remove(userModel);
            _dbContext.SaveChanges();
        }

        public List<UserModel> Get()
        {
            var users = _dbContext.Users.Include(user => user.Profile).Include(user => user.Courses).ToList();
            return users;
        }

        public UserModel? Get(int id)
        {
            var user = _dbContext.Users.Include(user => user.Profile).Include(user => user.Courses).FirstOrDefault(user => user.Id == id);
            return user;
        }

        public UserModel? Get(string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.UserName == userName);
            return user;
        }

        public UserModel? GetByNameExcludeId(string userName, int id)
        {
            var user = _dbContext.Users.Where(u => u.UserName == userName && u.Id != id).FirstOrDefault();
            return user;
        }

        public void Update(UserModel userModel)
        {
            _dbContext.Users.Update(userModel);
            _dbContext.SaveChanges();
        }
    }
}

