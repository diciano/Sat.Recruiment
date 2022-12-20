using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Model
{
    public class SuperUserUser : User
    {
        public SuperUserUser()
        {
            UserType = UserType.SuperUser;
        }

        public override void SetMoney(decimal money)
        {
            var percentage = 0m;
            if (money > 100)
            {
                percentage = 0.2m;
            }

            base.SetMoney(money * (1m + percentage));
        }
    }
}
