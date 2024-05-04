namespace ELearning.Data.Entities
{
    public class Choice : BaseEntity
    {
        public string Name { get; set; }
        public Answer Answer { get; set; }
    }
}