using System;
using System.Net;
using ConsoleHost.Infrastructure;
using ConsoleHost.Models;
using LinkedList.Collection;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new LinkedList<Student>();

            int choice;
            do
            {
                UI.Clear();   
                UI.PrintMenu();
            
                choice = UI.ReadIntValue("Enter your choice: ");
                switch (choice)
                {
                    case 1:
                    {
                        UI.PrintStudentsTable(collection);
                        break;
                    }
                    case 2:
                    {
                        var student = UI.ReadStudentModel();
                        collection.AddLast(student);
                        break;
                    }
                    case 3:
                    {
                        var student = UI.ReadStudentModel();
                        collection.AddFirst(student);
                        break;
                    }
                    case 4:
                    {
                        collection.RemoveFirst();
                        break;
                    }
                    case 5:
                    {
                        collection.RemoveLast();
                        break;
                    }
                    case 6:
                    {
                        var index = UI.ReadIntValue("Enter element index: ");
                        UI.PrintStudentColumns();
                        try
                        {
                            UI.PrintStudent(collection[index]);
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine("Index was out of range!");
                        }
                        break;
                    }
                    case 7:
                    {
                        collection.Sort(e => e.Name);
                        break;
                    }
                    case 8:
                    {
                        var index = UI.ReadIntValue("Enter element index: ");
                        var newStudent = UI.ReadStudentModel();
                        try
                        {
                            collection[index] = newStudent;
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine("Index was out of range!");
                        }
                        break;
                    }
                    case 9:
                    {
                        var findResult = collection.FindAll(student =>
                            student.Grant == 0 && student.Year == 2);
                        UI.PrintStudentsTable(findResult);
                        break;
                    }
                    default:
                        break;
                }
                
                UI.WaitToContinue();
            
            } while (choice != 0);
        }
    }
}