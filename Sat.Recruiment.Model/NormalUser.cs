using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Model
{
    public class NormalUser : User
    {
        public NormalUser()
        {
            UserType = UserType.Normal;
        }

        public override void SetMoney(decimal money)
        {
            //If new user is normal and has more than USD100
            var percentage = 0m;
            if (money > 100)
            {
                percentage = 0.12m;
            }
            else
            if (money < 100 && money > 10)
            {
                percentage = 0.8m;
            }

            base.SetMoney(money * (1m + percentage));
        }
    }
}
