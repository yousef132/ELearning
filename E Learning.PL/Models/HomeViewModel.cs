using ELearning.Data.Context;
using ELearning.Data.Entities;

namespace E_Learning.Models
{
    public class HomeViewModel
    {

        public string SearchValue { get; set; } = string.Empty;

        public ICollection<ApplicationUser> Instructors { get; set; } 

        public IReadOnlyList<Course> courses { get; set; }

        public int Students { get; set; }


        public string ImagePath {  get; set; }
    }
}
