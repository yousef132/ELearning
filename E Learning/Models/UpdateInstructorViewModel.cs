namespace E_Learning.Models
{
    public class UpdateInstructorViewModel: InstructorViewModel
    {
        public string? ImagePath { get; set; }

        public string? Id { get; set; }
        public IFormFile? Image { get; set; }

    }
}
