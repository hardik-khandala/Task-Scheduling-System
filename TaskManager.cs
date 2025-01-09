using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment3
{
    public delegate void taskCompleted(int id);
    class TaskManager
    {
        public static void taskcomp(int id) 
        {
            tasks.Where(x => x.TaskId == id).First().IsCompleted = true;
        }
        static List<Task> tasks = new List<Task>() 
        {
            new Task(){ TaskId=1, Title="Going Home",Deadline=new DateOnly(2025,01,12), Priority=priority.Low,IsCompleted=false},
            new Task(){ TaskId=2, Title="Assignment",Deadline=new DateOnly(2025,01,10), Priority=priority.Medium,IsCompleted=false},
        };
        public static void AddTask()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter a Deadline (dd/mm/yyyy)");
            DateOnly dateTime = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Priority (1. Low, 2. Medium, 3. High)");
            int priority = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Is completed? (true/false)");
            bool isCompleted = Convert.ToBoolean(Console.ReadLine());
            tasks.Add(new Task(title, dateTime, priority, isCompleted));
        }
        public static void MarkCompleted()
        {
            Console.WriteLine();
            Console.WriteLine("TaskID\t\tTitle\t\tDeadline\tPriority\tCompleted");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}\t\t{task.Title}\t{task.Deadline}\t{task.Priority}\t\t{task.IsCompleted}");
            }
            Console.WriteLine("\nEnter a ID to Complete Task");
            int cid = Convert.ToInt32(Console.ReadLine());
            taskCompleted tc = new taskCompleted(taskcomp);
            tc(cid);

        }
        public static void ViewAll()    
        {
            Console.WriteLine();
            Console.WriteLine("TaskID\t\tTitle\t\tDeadline\tPriority\tCompleted");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}\t\t{task.Title}\t{task.Deadline}\t{task.Priority}\t\t{task.IsCompleted}");
            }
        }
        public static void FilterTask()
        {

        }
        public static void TriggerDeadline()
        {

        }
    }
}
