
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
        manager.SubmitForReview(new TaskItem(6, "Test feature", "Divine", 3));
        manager.SubmitForReview(new TaskItem(7, "Refactor code", "Divine", 4));

        manager.ReviewNext();   
        manager.ReviewNext();   
        manager.ReviewNext();    
} 
}
}

