namespace E_Learning.Models
{
    public class EvaluateAssignmentViewModel
    {

        public int? Id { get; set; }
        public string UserId { get; set; }

        public int AssignmentId { get; set; }
        public string Path { get; set; }
        public double Mark { get; set; }
    }
}
