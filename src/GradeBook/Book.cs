using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> grades;
        public string Name;

        public Book(string name)
        {
            this.Name = name;
            this.grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if ((grade >= 0) && (grade <= 100))
                this.grades.Add(grade);
            else
                Console.WriteLine("Invalid grande value");
        }

        private double MinGrade()
        {
            double minGrade = double.MaxValue;
            foreach (double grade in this.grades)
                minGrade = Math.Min(grade, minGrade);
            return minGrade;
        }

        private double MaxGrade()
        {
            double maxGrade = double.MinValue;
            foreach (double grade in this.grades)
                maxGrade = Math.Max(grade, maxGrade);

            return maxGrade;
        }

        private double Average()
        {
            double sum = 0.0;
            foreach (double grade in this.grades)
            {
                sum += grade;
            }
            return sum / this.grades.Count;
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.High = this.MaxGrade();
            statistics.Low = this.MinGrade();
            statistics.Average = this.Average();

            return statistics;
        }

        public void ShowStatistics()
        {
            var statistics = this.GetStatistics();
            Console.WriteLine($"The lowest grade is {statistics.Low}");
            Console.WriteLine($"The highest grade is {statistics.High}");
            Console.WriteLine($"The average grade is {statistics.Average}");
        }

        public double GetLastGrade()
        {
            var lastGrade = 0.0;
            if (this.grades.Count != 0)
            {
                lastGrade = this.grades[grades.Count - 1];
            }
            return lastGrade;
        }
    }
}