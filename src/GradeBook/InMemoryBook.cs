using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        List<double> grades;

        public InMemoryBook(string name, ILetterGrade letterGrade) : base(name, letterGrade) // construct inherited class with name
        {
            this.Name = name;
            this.grades = new List<double>();
        }

        public override event GradeAddedDelegate GradeAdded;

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

        public override double GetLastGrade()
        {
            var lastGrade = 0.0d;
            if (this.grades.Count != 0)
            {
                lastGrade = this.grades[grades.Count - 1];
            }
            return lastGrade;
        }

        public override IEnumerable<double> GetGrades()
        {
            return grades;
        }
    }
}