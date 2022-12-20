using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sat.Recruiment.Model
{
    public class UserFactory
    {
        public static IUser CreateUser(UserType userType)
        {
            Type type = System.Reflection.Assembly
                .Load("Sat.Recruiment.Model")
                .GetType("Sat.Recruiment.Model." + userType.ToString() + "User");
            var result = Activator.CreateInstance(type);
            return (IUser)result;
        }
    }
}
