using System.ComponentModel.DataAnnotations;

namespace ELearning.Models
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Not An Email")]
        public string Email { get; set; }
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

    }
}
