using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    // Student class
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
    }

    // LINQ Demo class
    public class LinqDemo
    {
        public void Run()
        {
            var students = new List<Student>
            {
                new Student { Name = "Alice", Age = 20, Grade = "A" },
                new Student { Name = "Bob", Age = 22, Grade = "B" },
                new Student { Name = "Charlie", Age = 21, Grade = "A" },
                new Student { Name = "David", Age = 23, Grade = "C" },
                new Student { Name = "Eve", Age = 20, Grade = "B" }
            };

            // LINQ query
            var olderStudents =
                students
                    .Where(s => s.Age > 21)
                    .Select(s => new { s.Name });

            // Output
            foreach (var student in olderStudents)
            {
                Console.WriteLine($"{student.Name} more than 21 years old.");
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            LinqDemo demo = new LinqDemo();
            demo.Run();

            Console.ReadLine();
        }
    }
}
