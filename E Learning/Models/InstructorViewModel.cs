using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class InstructorViewModel
    {
        public string DisplayName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //public string Title { get; set; }

    }
}
