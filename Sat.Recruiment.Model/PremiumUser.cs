using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Model
{
    public class PremiumUser : User
    {
        public PremiumUser()
        {
            UserType = UserType.Premium;
        }

        public override void SetMoney(decimal money)
        {
            var percentage = 0m;
            if (money > 100)
            {
                percentage = 1m;
            }

            base.SetMoney(money * (1m + percentage));
        }
    }
}
