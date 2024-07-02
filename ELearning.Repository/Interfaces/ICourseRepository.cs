namespace ELearning.BLL.Interfaces
{
    public interface ICourseRepository
    {
        int GetNumberOfSoldCourses();
        int GetNumberOfCourses();

        IQueryable<Tuple<string, int>> GetNumberOfSellingForEachCourse();


    }
}
