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

            var book = new Book("Pedro's grade book");

            Console.WriteLine("Start inserting grades. Press Q to exit.");
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
                    Console.WriteLine($"Inserted grade: {book.GetLastGrade()}");
                    continue;
                }

                // Add grade as letter
                if (Regex.IsMatch(input, letterRegex))
                {
                    if (input.Length == 1)
                    {
                        book.AddGrade(input.ToCharArray()[0]);
                        Console.WriteLine($"Inserted grade: {book.GetLastGrade()}");
                    }
                }
            }

            Console.WriteLine("--- Book statistics ---");
            book.ShowStatistics();
        }
    }
}