namespace E_Learning.Models
{
    public class QuestionViewModel
    {
        public int? Id { get; set; } = 0;
        public int? ExamId { get; set; }
        public string Text { get; set; }

        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }

        public int AnswerChoice { get; set; }
    }
}
