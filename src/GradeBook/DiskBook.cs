using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name, ILetterGrade letterGrade) : base(name, letterGrade) { }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if ((grade < 0) || (grade > 100))
            {
                throw new ArgumentException($"Invalid {nameof(grade)} value: {grade}");
            }

            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade.ToString());
            }
            GradeAdded(this, new BookEventArgs(grade));
        }

        public override IEnumerable<double> GetGrades()
        {
            var grades = new List<double>();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        return grades;
                    }
                    try
                    {
                        var grade = double.Parse(line);
                        grades.Add(grade);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Failed to parse line to double: {ex.Message}");
                    }
                }
            }
        }

        public override double GetLastGrade()
        {
            var grades = GetGrades().ToList();
            if (grades.Count != 0)
            {
                return grades[grades.Count - 1];
            }
            return 0.0;
        }
    }
}