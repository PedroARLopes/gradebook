using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public const string CATEGORY = "Science";
        List<double> grades;
        public string Name { get; private set; }

        public Book(string name)
        {
            this.Name = name;
            this.grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    this.AddGrade(90);
                    break;
                case 'B':
                    this.AddGrade(80);
                    break;
                case 'C':
                    this.AddGrade(70);
                    break;
                default:
                    this.AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if ((grade >= 0) && (grade <= 100))
                this.grades.Add(grade);
            else
                throw new ArgumentException($"Invalid {nameof(grade)} value: {grade}");
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

        public char LetterGrade(double grade)
        {
            char letter;
            switch (grade)
            {
                case var d when d >= 90.0:
                    letter = 'A';
                    break;
                case var d when d >= 80.0:
                    letter = 'B';
                    break;
                case var d when d >= 70:
                    letter = 'C';
                    break;
                case var d when d >= 60:
                    letter = 'D';
                    break;
                default:
                    letter = 'F';
                    break;
            }
            return letter;
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.High = this.MaxGrade();
            statistics.Low = this.MinGrade();
            statistics.Average = this.Average();
            statistics.Letter = this.LetterGrade(statistics.Average);

            return statistics;
        }

        public void ShowStatistics()
        {
            var statistics = this.GetStatistics();
            Console.WriteLine($"The lowest grade is {statistics.Low}");
            Console.WriteLine($"The highest grade is {statistics.High}");
            Console.WriteLine($"The average grade is {statistics.Average}");
            Console.WriteLine($"The average letter grade is {statistics.Letter}");
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