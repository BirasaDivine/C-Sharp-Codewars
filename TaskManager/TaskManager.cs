using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace TaskManagerApp
{
   public class TaskManager 
{
    private List<TaskItem> _tasks = new List<TaskItem>();
    private Dictionary<string , List<TaskItem>> _tasksByAssignee = new Dictionary<string, List<TaskItem>>();
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
    public void AssignTask(TaskItem task)
        {
            
            AddTask(task);
            if (_tasksByAssignee.ContainsKey(task.AssignedTo)){
                _tasksByAssignee[task.AssignedTo].Add(task);
            }else{
                List<TaskItem> newTask = new List<TaskItem>();
                newTask.Add(task);
                _tasksByAssignee.Add(task.AssignedTo, newTask);
            }

             
        }
    public void DisplayByAssignee(string assignee)
{
    if (_tasksByAssignee.ContainsKey(assignee))
    {
        Console.WriteLine($"Tasks for {assignee}:");
        foreach (TaskItem task in _tasksByAssignee[assignee])
            {
                Console.WriteLine($"  [{task.Id}] {task.Title} - Priority: {task.Priority}, Complete: {task.IsComplete}");
            }
    }
    else
    {
        Console.WriteLine("no tasks found");
        
    }
    
}
    private Queue<TaskItem> _pendingReview = new Queue<TaskItem>();
    public void SubmitForReview(TaskItem task)
        {
            task.IsComplete = true;
            _pendingReview.Enqueue(task);
            Console.WriteLine($"Task {task.Title} added");
        }
    
    public void ReviewNext()
        {
            if (_pendingReview.Count > 0)  {
                TaskItem next= _pendingReview.Dequeue();
                Console.WriteLine($"Reviewing: {next.Title}");
            }
            else
            {
                Console.WriteLine($" Nothing to review");
            }
                
        }
    private Stack<TaskItem> _recentlyCompleted = new Stack<TaskItem>();
    public void CompletedTask(TaskItem task)
        {
            task.IsComplete = true;
            _recentlyCompleted.Push(task);
            Console.WriteLine($"{task.Title} completed");
        }
    public void UndoLastCompletion()
        {
           if (_recentlyCompleted.Count > 0)
            {
                TaskItem mostRecent= _recentlyCompleted.Pop();
                mostRecent.IsComplete=false;
                Console.WriteLine($"Undo: {mostRecent.Title}");
            } 
            else
            {
                Console.WriteLine($" Nothing to Undo");
            }
        }
    

} 
}
