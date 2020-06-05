using System;
using System.Text.RegularExpressions;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var letterRegex = @"^[a-zA-Z]$";
            var numberRegex = @"^[\d.]+$";

            Console.WriteLine("Insert book name: ");
            var book = new InMemoryBook(Console.ReadLine());
            book.GradeAdded += OnGradeAdded;

            Console.WriteLine("Start inserting grades. Press Q to exit.");
            EnterGrades(letterRegex, numberRegex, book);

            Console.WriteLine($"--- Book statistics for {book.Name} ---");
            Console.WriteLine($"The book category is {InMemoryBook.CATEGORY}");
            book.ShowStatistics();
        }

        private static void EnterGrades(string letterRegex, string numberRegex, Book book)
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