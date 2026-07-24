using System;
using System.Collections.Generic;


namespace TaskManagerApp
{
   public class TaskManager 
{
    private List<TaskItem> _tasks = new List<TaskItem>();
    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
    public void DisplayAll()
    {
        foreach (TaskItem task in _tasks)
        {
            Console.WriteLine($"[{task.Id}] {task.Title} - Assigned to: {task.AssignedTo}, " +
                                   $"Priority: {task.Priority}, Complete: {task.IsComplete}");
        }
    }
} 
}
