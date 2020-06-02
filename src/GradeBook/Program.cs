using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 88.4, 81.67, 99.5 };

            double result = 0.0;
            foreach (double grade in grades)
                result += grade;

            var average = result / grades.Count;
            Console.WriteLine($"Average of grades: {average:N1}");
        }
    }
}
