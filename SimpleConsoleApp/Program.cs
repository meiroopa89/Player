// using System;

// namespace SimpleConsoleApp
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Welcome to Simple Console App!");
//             Console.Write("Please enter your name: ");
//             string name = Console.ReadLine();
//             Console.WriteLine($"Hello, {name}! Welcome to the world of MSBuild.");
//         }
//     }
// }


using System;
using System.Collections.Generic;

namespace SimpleToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store tasks
            List<string> tasks = new List<string>();

            while (true)
            {
                // Display menu options
                Console.WriteLine("To-Do List Application");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Mark Task as Complete");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. View Tasks");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                // Get user input
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": // Add Task
                        Console.Write("Enter the task to add: ");
                        string newTask = Console.ReadLine();
                        tasks.Add(newTask);
                        Console.WriteLine("Task added successfully!");
                        break;

                    case "2": // Mark Task as Complete
                        Console.Write("Enter the task number to mark as complete: ");
                        int completeIndex;
                        if (int.TryParse(Console.ReadLine(), out completeIndex) && completeIndex >= 0 && completeIndex < tasks.Count)
                        {
                            Console.WriteLine($"Task '{tasks[completeIndex]}' marked as complete.");
                            tasks.RemoveAt(completeIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number!");
                        }
                        break;

                    case "3": // Delete Task
                        Console.Write("Enter the task number to delete: ");
                        int deleteIndex;
                        if (int.TryParse(Console.ReadLine(), out deleteIndex) && deleteIndex >= 0 && deleteIndex < tasks.Count)
                        {
                            Console.WriteLine($"Task '{tasks[deleteIndex]}' deleted.");
                            tasks.RemoveAt(deleteIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number!");
                        }
                        break;

                    case "4": // View Tasks
                        Console.WriteLine("Tasks:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i}. {tasks[i]}");
                        }
                        break;

                    case "5": // Exit
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option! Please select again.");
                        break;
                }

                // Add a blank line for clarity
                Console.WriteLine();
            }
        }
    }
}
