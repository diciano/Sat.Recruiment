using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruiment.Business;
using Sat.Recruiment.Business.Interfaces;
using Sat.Recruiment.Model;
using Sat.Recruiment.Model.Exceptions;
using Sat.Recruiment.Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserBusiness userBusiness;

        public UsersController(IUserBusiness business)
        {
            userBusiness = business;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            var validate = request.Validate(new ValidationContext(request));

            if (validate.Count() > 0)
            {
                var errors = "";
                foreach (var item in validate)
                {
                    errors += item.ErrorMessage + Environment.NewLine;
                }
                return BadRequest(errors);
            }

            // todo raise error if false
            if (!Enum.TryParse(request.UserType, out UserType ut))
            {
                return BadRequest("User type is invalid.");
            }

            if (!decimal.TryParse(request.Money, out decimal money))
            {
                return BadRequest("Money format is invalid.");
            }

            var newUser = UserFactory.CreateUser(ut);
            if (newUser != null) 
            {
                newUser.Name = request.Name;
                newUser.Email = EmailHelper.NormalizeEmail(request.Email);
                newUser.Address = request.Address;
                newUser.Phone = request.Phone;
                newUser.SetMoney(money);
            };

            try
            {
                await userBusiness.AddUser(newUser);
                Debug.WriteLine("User Created");

                return Ok(new CreateUserResponse { IsSuccess = true, Message = "User Created" });
            }
            catch (DuplicateUserException ex) 
            {
                Debug.WriteLine($"Duplicate error: {ex.Message}");
                return Ok(new CreateUserResponse { IsSuccess = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unknown error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await userBusiness.GetUsers();
                return Ok(users);
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Unknown error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
