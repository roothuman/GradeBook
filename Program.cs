using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Moss GradeBook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);


            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name} ");
            Console.WriteLine($"The Average grade is {stats.Average:N2} ");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The Lowest grade is {stats.Low} ");
            Console.WriteLine($"The Letter grade is {stats.Letter} ");

        }

        private static void EnterGrades(Book book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or press 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                finally
                {
                    System.Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A Grade was added");
        }
    }
}