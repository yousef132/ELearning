namespace ELearning.Data.Entities
{
    public class TimedEntity
    {
        public DateTime Open { get; set; }
        public DateTime Close { get; set; }
        public TimeSpan Duration => Close.Subtract(Open);
        public double Grade {  get; set; }
    }
}