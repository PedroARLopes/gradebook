using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);
        public abstract void AddGrade(char grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {
        public const string CATEGORY = "Science";
        List<double> grades;

        public InMemoryBook(string name) : base(name) // construct inherited class with name
        {
            this.Name = name;
            this.grades = new List<double>();
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(char letter)
        {
            double grade;
            switch (letter)
            {
                case 'A':
                    grade = 90;
                    break;
                case 'B':
                    grade = 80;
                    break;
                case 'C':
                    grade = 70;
                    break;
                default:
                    grade = 0;
                    break;
            }
            this.AddGrade(grade);
        }

        public override void AddGrade(double grade)
        {
            if ((grade >= 0) && (grade <= 100))
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new BookEventArgs(grade));
                }
            }
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
                sum += grade;
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

        public override Statistics GetStatistics()
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
            Console.WriteLine($"The lowest grade is {statistics.Low:N1}");
            Console.WriteLine($"The highest grade is {statistics.High:N1}");
            Console.WriteLine($"The average grade is {statistics.Average:N1}");
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