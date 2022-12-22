using Entities;
using System;
using System.ComponentModel.DataAnnotations;
using WebFramework.Api;

namespace Admin.Models.Authentication
{
    public class SignUpDto : BaseDto<SignUpDto, User, Guid>
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required]
        [Compare(nameof(PassWord), ErrorMessage = "رمز عبور های وارد شده شبیه به هم نیستند!")]
        public string PassWordConfirmation { get; set; }

    }
}
