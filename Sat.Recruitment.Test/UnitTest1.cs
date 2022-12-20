using System;
using System.Dynamic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruiment.Business;
using Sat.Recruiment.Dao;
using Sat.Recruiment.Model;
using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userDao = new UserDao("\\Files\\Users.txt");
            var userBusiness = new UserBusiness(userDao);
            var userController = new UsersController(userBusiness);

            var request = new CreateUserRequest
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            var result = userController.CreateUser(request).Result;

            Assert.NotNull(result);
            Assert.True(((ObjectResult)result).StatusCode.HasValue);
            Assert.True(((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.OK 
                || ((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void Test2()
        {
            var userDao = new UserDao("\\Files\\Users.txt");
            var userBusiness = new UserBusiness(userDao);
            var userController = new UsersController(userBusiness);

            var request = new CreateUserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };

            var result = userController.CreateUser(request).Result;

            Assert.NotNull(result);
            Assert.True(((ObjectResult)result).StatusCode.HasValue);
            Assert.True(((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.OK
                || ((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestBadRequest()
        {
            var userDao = new UserDao("\\Files\\Users.txt");
            var userBusiness = new UserBusiness(userDao);
            var userController = new UsersController(userBusiness);

            var request = new CreateUserRequest
            {
                Name = "",
                Email = "",
                Address = "",
                Phone = "",
                UserType = "Normal",
                Money = "124"
            };

            var result = userController.CreateUser(request).Result;

            Assert.NotNull(result);
            Assert.True(((ObjectResult)result).StatusCode.HasValue);
            Assert.True(((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestBadUserType()
        {
            var userDao = new UserDao("\\Files\\Users.txt");
            var userBusiness = new UserBusiness(userDao);
            var userController = new UsersController(userBusiness);

            var request = new CreateUserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Regular",
                Money = "124"
            };

            var result = userController.CreateUser(request).Result;

            Assert.NotNull(result);
            Assert.True(((ObjectResult)result).StatusCode.HasValue);
            Assert.True(((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestMoneyInvalidFormat()
        {
            var userDao = new UserDao("\\Files\\Users.txt");
            var userBusiness = new UserBusiness(userDao);
            var userController = new UsersController(userBusiness);

            var request = new CreateUserRequest
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "12a4"
            };

            var result = userController.CreateUser(request).Result;

            Assert.NotNull(result);
            Assert.True(((ObjectResult)result).StatusCode.HasValue);
            Assert.True(((ObjectResult)result).StatusCode.Value == (int)HttpStatusCode.BadRequest);
        }
    }
}
