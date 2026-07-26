
namespace TaskManagerApp
{
    class Program
   {
    static void Main()
    {   
         TaskManager manager = new TaskManager();
        // TaskItem task1 = new  TaskItem( 1 ,  "Study Csharp", "Divine" , 4);
        // TaskItem task2 = new  TaskItem( 2 ,  "Enjoyment", "Divine" , 1);
        // manager.AddTask(task1);
        // manager.AddTask(task2);
        // manager.AssignTask(new TaskItem(3, "Fix bug", "Divine", 5));
        // manager.AssignTask(new TaskItem(4, "Write docs", "Divine", 2));
        // manager.AssignTask(new TaskItem(5, "Design UI", "Bob", 3));

        // manager.DisplayByAssignee("Divine");
        // manager.DisplayByAssignee("Birasa");  
       
        TaskItem task8 = new TaskItem(8, "Deploy app", "Divine", 5);
        manager.CompletedTask(task8);
        Console.WriteLine($"Before undo, IsComplete: {task8.IsComplete}");   // True

        manager.UndoLastCompletion();
        Console.WriteLine($"After undo, IsComplete: {task8.IsComplete}");    // False — proves the undo actually worked

        manager.UndoLastCompletion();   // "Nothing to undo." — stack's empty now    
} 
}
}

