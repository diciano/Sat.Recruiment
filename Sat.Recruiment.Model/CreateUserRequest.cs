using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Sat.Recruiment.Model
{
    public class CreateUserRequest : IValidatableObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The email is required")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The address is required")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The phone is required")]
        public string Phone { get; set; }

        public string UserType { get; set; }    

        public string Money { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = string.Empty;
            var fields = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("The name is required", new[] { nameof(Name) });
                //Validate if Name is null
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                //Validate if Email is null
                yield return new ValidationResult("The email is required", new[] { nameof(Email) });
            }
            if (string.IsNullOrWhiteSpace(Address))
            {
                //Validate if Address is null
                yield return new ValidationResult("The address is required", new[] { nameof(Address) });
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                //Validate if Phone is null
                yield return new ValidationResult("The phone is required", new[] { nameof(Phone) });
            }
        }
    }
}
