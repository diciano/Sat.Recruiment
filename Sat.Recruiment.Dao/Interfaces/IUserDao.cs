using Sat.Recruiment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Dao.Interfaces
{
    public interface IUserDao
    {
        Task<IUser> ReadUser();

        void CloseFile();

        Task AddUser(IUser newUser);
    }
}
