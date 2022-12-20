using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Model
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        UserType UserType { get; set; }
        decimal Money { get; set; }

        void SetMoney(decimal money);
        bool IsDuplicated(IUser user);
    }
}
