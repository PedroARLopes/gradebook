using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Pedro's grade book");
            book.AddGrade(90.2);
            book.AddGrade(88.54);
            book.AddGrade(76.5);
            book.ShowStatistics();
        }
    }
}