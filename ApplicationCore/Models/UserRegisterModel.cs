using ApplicationCore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Email should have right format")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //minimum of 8 chars
        // 1 number, 1 uppercase, 1 lowercase
        // strong password
        // [RegularExpression()]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [YearValidationAttribute(1900)]
        public DateTime DateOfBirth { get; set; }
    }
}
