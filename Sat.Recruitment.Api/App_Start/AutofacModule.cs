using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Sat.Recruiment.Business;
using Sat.Recruiment.Business.Interfaces;
using Sat.Recruiment.Dao;
using Sat.Recruiment.Dao.Interfaces;

namespace Sat.Recruitment.Api.App_Start
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var confBuilder = new ConfigurationBuilder();
            confBuilder.AddJsonFile("autofac.json");

            builder.RegisterModule(new ConfigurationModule(confBuilder.Build()));

            //builder.RegisterType<UserDao>().As<IUserDao>();
            builder.RegisterType<UserBusiness>().As<IUserBusiness>();
        }
    }
}
