using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class CreateInstructorViewModel: InstructorViewModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public IFormFile Image { get; set; }



    }
}
