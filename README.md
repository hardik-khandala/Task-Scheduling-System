# Task Manager System

## Overview
The **Task Manager System** is a .NET Console Application that helps users manage their tasks effectively. It provides functionalities to add, mark as completed, filter, sort, and notify users of task deadlines. This application is built with features like events, delegates, and lambda expressions for better performance and flexibility.

---

## Features
1. **Add New Tasks**: Create tasks with a title, deadline, priority, and completion status.
2. **Mark Tasks as Completed**: Use a delegate to update the completion status of tasks.
3. **Sort Tasks**: Sort tasks by different criteria such as deadline, priority, or title length.
4. **Filter Tasks**: Dynamically filter tasks using custom conditions with `Func` delegates.
5. **Deadline Notifications**: Notify users of tasks whose deadlines are within 24 hours via events.

---

## How to Clone and Run the Project

### Prerequisites
Before you begin, make sure you have the following installed:
- .NET SDK (6.0 or later)
- Visual Studio or any compatible IDE

### Steps to Clone and Run the Application
1. Open a terminal or command prompt.
2. Run the following command to clone the repository:
   ```bash
   git clone https://github.com/hardik-khandala/Task-Scheduling-System.git
   cd Task-Scheduling-System
   dotnet build
   dotnet run
   ```
Task Manager System
-------------------
1. Add a New Task
2. Mark a Task as Completed
3. View All Tasks
4. Filter Tasks by Custom Criteria
5. Trigger Deadline Notifications
6. Exit
