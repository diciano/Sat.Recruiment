using Sat.Recruiment.Business.Interfaces;
using Sat.Recruiment.Dao.Interfaces;
using Sat.Recruiment.Model;
using Sat.Recruiment.Model.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruiment.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDao userDao;

        public UserBusiness(IUserDao dao)
        {
            userDao = dao;
        }

        public async Task AddUser(IUser newUser)
        {
            try
            { 
                IUser user;
                while(!((user = await userDao.ReadUser()) is null))
                {
                    if (newUser.IsDuplicated(user))
                    {
                        throw new DuplicateUserException($"User {newUser.Name} already exists.");
                    }
                }
                await userDao.AddUser(newUser);
            }
            finally
            {
                userDao.CloseFile();
            }
        }

        public async Task<IEnumerable<IUser>> GetUsers()
        {
            var result = new List<IUser>();
            try
            {
                IUser user;
                while (!((user = await userDao.ReadUser()) is null))
                {
                    result.Add(user); 
                }
                return result;
            }
            finally
            {
                userDao.CloseFile();
            }
        }
    }
}
