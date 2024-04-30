using System.ComponentModel.DataAnnotations;

namespace ELearning.Models
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]

        public string Email { get; set; }   
    }
}
