using System;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruiment.Model
{
    public class User : IUser
    {
        protected decimal money;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get { return money; } set { money = value; } }

        public bool IsDuplicated(IUser user)
        {
            if (Email == user.Email || Phone == user.Phone)
            {
                return true;
            }

            if (Name == user.Name && Address == user.Address)
            {
                return true;
            }

            return false;

        }

        public virtual void SetMoney(decimal money) 
        {
            this.money = money;
        }
    }
}
