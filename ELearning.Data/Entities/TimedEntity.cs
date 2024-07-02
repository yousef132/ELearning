namespace ELearning.Data.Entities
{
    public class TimedEntity
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public TimeSpan Duration { get; set; }
        public double Grade {  get; set; }
    }
}