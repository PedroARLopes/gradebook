namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        void AddGrade(char grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}