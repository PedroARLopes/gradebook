using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var letterRegex = @"^[a-zA-Z]$";
            var numberRegex = @"^[\d.]+$";
            var letterGrade = new LetterGrade();

            Console.WriteLine("Insert book name: ");
            // TODO: create switch to select book type?
            var book = new DiskBook(Console.ReadLine(), letterGrade);
            book.GradeAdded += OnGradeAdded;

            Console.WriteLine("Start inserting grades. Press Q to exit.");
            EnterGrades(letterRegex, numberRegex, book);

            Console.WriteLine($"--- Book statistics for {book.Name} ---");
            var grades = book.GetGrades();
            for (int i = 0; i < grades.Count(); i++)
                Console.WriteLine($"Grade {i + 1}: {grades.ElementAt(i)}");
            Console.WriteLine($"The lowest grade is {book.GetLow():N1}");
            Console.WriteLine($"The higuest grade is {book.GetHigh():N1}");
            Console.WriteLine($"The average grade is {book.GetAverage():N1}");
        }

        private static void EnterGrades(string letterRegex, string numberRegex, IBook book)
        {
            while (true)
            {
                Console.Write("Insert grade number or letter: ");
                var input = Console.ReadLine();
                if (input == "Q" || input == "q")
                {
                    break;
                }

                // Add a number grade
                if (Regex.IsMatch(input, numberRegex))
                {
                    var grade = double.Parse(input);
                    try
                    {
                        book.AddGrade(grade);
                    }
                    // There can be multiple catches
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    continue;
                }

                // Add grade as letter
                if (Regex.IsMatch(input, letterRegex))
                {
                    if (input.Length == 1)
                    {
                        book.AddGrade(input.ToCharArray()[0]);
                    }
                }
            }
        }

        static void OnGradeAdded(object sender, BookEventArgs e)
        {
            Console.WriteLine($"Inserted grade: {e.grade}");
        }
    }
}