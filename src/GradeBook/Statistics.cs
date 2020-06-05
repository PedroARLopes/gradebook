using System;
using System.Linq;

namespace GradeBook
{
    public static class BookStatisticExtensions
    {
        public static double GetAverage(this IBook book)
        {
            var grades = book.GetGrades();
            double sum = 0.0;
            foreach (double grade in grades)
                sum += grade;
            return sum / grades.Count();
        }

        public static double GetLow(this IBook book)
        {
            var grades = book.GetGrades();
            double min = double.MaxValue;
            foreach (double grade in grades)
                min = Math.Min(grade, min);
            return min;
        }

        public static double GetHigh(this IBook book)
        {
            var grades = book.GetGrades();
            double max = double.MinValue;
            foreach (double grade in grades)
                max = Math.Max(grade, max);
            return max;
        }
    }
}