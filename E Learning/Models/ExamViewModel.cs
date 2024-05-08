namespace E_Learning.Models
{
    public class ExamViewModel
    {
        public int? CourseId { get; set; }
        public string Name { get; set; }
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public double Grade { get; set; }
    }
}
