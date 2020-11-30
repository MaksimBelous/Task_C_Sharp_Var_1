using System;
using ConsoleHost.Models;
using LinkedList.Collection;

namespace ConsoleHost.Infrastructure
{
    public static class UI
    {
        private static readonly string _studentRowFormat = "{0,15} {1,15} {2,15}";
        
        public static void PrintMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Print list");
            Console.WriteLine("2. Add new element to the head");
            Console.WriteLine("3. Add new element to the tail");
            Console.WriteLine("4. Remove first element");
            Console.WriteLine("5. Remove last element");
            Console.WriteLine("6. Get element from position");
            Console.WriteLine("7. Sort list");
            Console.WriteLine("8. Change element from position");
            Console.WriteLine("9. Find elements");
            Console.WriteLine("0. Exit");
        }

        public static void PrintStudentsTable(LinkedList<Student> students)
        {
            PrintStudentColumns();
            foreach (Student student in students)
            {
                PrintStudent(student);
            }
        }

        public static void PrintStudentColumns()
        {
            Console.WriteLine(String.Format(_studentRowFormat, "Name", "Grant", "University Year"));
        }

        public static void PrintStudent(Student student)
        {
            Console.WriteLine(String.Format(_studentRowFormat, student.Name, student.Grant,
                student.Year));
        }

        public static int ReadIntValue(string msg)
        {
            int value;
            do
            {
                Console.Write(msg);
            } while (!Int32.TryParse(Console.ReadLine(), out value));

            return value;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void WaitToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static Student ReadStudentModel()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            double grant;
            do
            {
                Console.Write("Enter student's grant: ");
            } while (!Double.TryParse(Console.ReadLine(), out grant));

            var year = ReadIntValue("Enter student's university year: ");

            return new Student {Name = name, Grant = grant, Year = year};
        }
    }
}