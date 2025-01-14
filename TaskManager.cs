using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3
{
    public delegate void TaskCompleted(int id);

    class TaskManager
    {
        public static event Action<Task> TaskDeadlineApproaching;

        static List<Task> tasks = new List<Task>()
        {
            new Task(){ TaskId=1, Title="Going Home", Deadline=new DateOnly(2025,01,12), Priority=priority.Low, IsCompleted=false},
            new Task(){ TaskId=2, Title="Assignment", Deadline=new DateOnly(2025,01,10), Priority=priority.Medium, IsCompleted=false},
        };

        public static void AddTask()
        {
            Console.WriteLine("\nEnter a Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter a Deadline (dd/mm/yyyy):");
            DateOnly deadline = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Priority (1. Low, 2. Medium, 3. High):");
            int priority = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is completed? (true/false):");
            bool isCompleted = Convert.ToBoolean(Console.ReadLine());

            tasks.Add(new Task(title, deadline, priority, isCompleted));
            Console.WriteLine("Task added successfully!");
        }

        public static void MarkCompleted()
        {
            Console.WriteLine("\nTaskID\t\tTitle\t\tDeadline\tPriority\tCompleted");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}\t\t{task.Title}\t{task.Deadline}\t{task.Priority}\t\t{task.IsCompleted}");
            }

            Console.WriteLine("\nEnter the ID of the task to mark as completed:");
            int id = Convert.ToInt32(Console.ReadLine());

            TaskCompleted taskCompletedDelegate = new TaskCompleted((taskId) =>
            {
                var task = tasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null)
                {
                    task.IsCompleted = true;
                    Console.WriteLine($"Task {taskId} marked as completed.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            });

            taskCompletedDelegate(id);
        }

        public static void ViewAll()
        {
            Console.WriteLine("\nTaskID\t\tTitle\t\tDeadline\tPriority\tCompleted");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskId}\t\t{task.Title}\t{task.Deadline}\t{task.Priority}\t\t{task.IsCompleted}");
            }
        }

        public static void FilterTask()
        {
            Console.WriteLine("\nChoose a filter criterion:");
            Console.WriteLine("1. High Priority\n2. Incomplete Tasks\n3. Tasks Due Within a Week");
            int choice = Convert.ToInt32(Console.ReadLine());

            Func<Task, bool> filter = choice switch
            {
                1 => task => task.Priority == priority.High,
                2 => task => !task.IsCompleted,
                3 => task => task.Deadline <= DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                _ => null
            };

            if (filter != null)
            {
                var filteredTasks = tasks.Where(filter).ToList();
                Console.WriteLine("\nFiltered Tasks:");
                foreach (var task in filteredTasks)
                {
                    Console.WriteLine($"ID: {task.TaskId}, Title: {task.Title}, Deadline: {task.Deadline}, Priority: {task.Priority}, Completed: {task.IsCompleted}");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public static void TriggerDeadline()
        {
            foreach (var task in tasks)
            {
                if (task.Deadline == DateOnly.FromDateTime(DateTime.Now.AddDays(1)))
                {
                    TaskDeadlineApproaching?.Invoke(task);
                }
            }
        }

        public static void SortTasks()
        {
            Console.WriteLine("\nChoose a sorting criterion:");
            Console.WriteLine("1. Deadline\n2. Priority\n3. Title Length");
            int choice = Convert.ToInt32(Console.ReadLine());

            Comparison<Task> comparison = choice switch
            {
                1 => (x, y) => x.Deadline.CompareTo(y.Deadline),
                2 => (x, y) => x.Priority.CompareTo(y.Priority),
                3 => (x, y) => x.Title.Length.CompareTo(y.Title.Length),
                _ => null
            };

            if (comparison != null)
            {
                tasks.Sort(comparison);
                Console.WriteLine("Tasks sorted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    class NotificationService
    {
        public NotificationService()
        {
            TaskManager.TaskDeadlineApproaching += Notify;
        }

        private void Notify(Task task)
        {
            Console.WriteLine($"Notification: Task '{task.Title}' with ID {task.TaskId} has a deadline approaching on {task.Deadline}!");
        }
    }
}
