using Sat.Recruiment.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task AddUser(IUser newUser);

        Task<IEnumerable<IUser>> GetUsers();
    }
}
