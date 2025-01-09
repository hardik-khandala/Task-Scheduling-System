using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{

    enum priority
    {
        Low = 1, 
        Medium, 
        High
    }
    internal class Task
    {
        static int id = 3;
        public int TaskId { get; set; }
        public string Title { get; set; }
        public DateOnly Deadline { get; set; }
        public priority Priority {  get; set; }
        public bool IsCompleted { get; set; }
        public Task(string title, DateOnly deadline, int pr, bool isCompleted) 
        {
            this.TaskId = id++;
            this.Title = title;
            this.Deadline = deadline;
            this.Priority = (priority)pr;
            this.IsCompleted = isCompleted;
        }
        public Task() { }
    }
}
