namespace E_Learning.Models
{
    public class DashbordViewModel
    {
        public int NOStudents { get; set; }

        public int NOCourses { get; set; }
        public int NOInstructors { get; set; }

        public int NOSoldCourse { get; set; }

        public List<Tuple<string, int>> NumberOfSellingForEachCourse { get; set; }
    }
}
