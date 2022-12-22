using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Authentication
{
    public class SignUpOtpDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Otp { get; set; }
    }
}
