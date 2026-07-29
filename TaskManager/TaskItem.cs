public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string AssignedTo { get; set; }
    public int Priority { get; set; }
    public bool IsComplete { get; set; }

    public TaskItem(int id , string title, string assignedTo , int priority  )
    {
        if (priority < 1 || priority > 5 )

            throw new ArgumentException("Priority must between 1 and 5");

        Id = id;
        Title = title ;
        AssignedTo = assignedTo;
        Priority = priority;
        IsComplete = false;
    }
}