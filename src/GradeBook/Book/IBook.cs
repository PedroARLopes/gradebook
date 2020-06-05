using System.Collections.Generic;

namespace GradeBook
{
    public interface IBook
    {
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
        void AddGrade(double grade);
        void AddGrade(char grade);
        double GetLastGrade();
        IEnumerable<double> GetGrades();
    }
}