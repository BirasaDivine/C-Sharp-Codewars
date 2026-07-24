
namespace TaskManagerApp
{
    class Program
   {
    static void Main()
    {   
        TaskManager manager = new TaskManager();
        TaskItem task1 = new  TaskItem( 1 ,  "Study Csharp", "Divine" , 4);
        TaskItem task2 = new  TaskItem( 2 ,  "Enjoyment", "Divine" , 1);
        manager.AddTask(task1);
        manager.AddTask(task2);
        manager.DisplayAll();
    }
} 
}

