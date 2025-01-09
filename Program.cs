using System;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nTask Manager System");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Add a New Task\n2. Mark a Task as Completed\n3. View All Tasks\n4. Filter Tasks by Custom Criteria\n5. Trigger Deadline Notifications\n6. Exit\nEnter a Choise");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        TaskManager.AddTask();
                        break;
                    case 2:
                        TaskManager.MarkCompleted();
                        break;
                    case 3:
                        TaskManager.ViewAll();
                        break;
                    case 4:
                        TaskManager.FilterTask();
                        break;
                    case 5:
                        TaskManager.TriggerDeadline();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Please choose Proper Options!!!");
                        break;
                }
            }
        }
    }
}