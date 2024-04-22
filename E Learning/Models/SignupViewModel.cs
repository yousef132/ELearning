using System.ComponentModel.DataAnnotations;

namespace ELearning.Models
{
    public class SignupViewModel
    {

        
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Not An Email")]
        public string Email { get; set; }
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]

        [MaxLength(10)]
        [Compare(nameof(Password) , ErrorMessage ="Password Dismatch")]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
