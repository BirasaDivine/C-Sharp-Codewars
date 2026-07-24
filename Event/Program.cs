using System;

public enum Priority
{
    Low,     // For routine notifications
    Medium,  // For important notifications
    High,    // For time-sensitive notifications
    Urgent   // For emergency notifications
}

public class NotificationEventArgs : EventArgs
{
    public string Department { get; }
    public string Message { get; }
    public Priority Priority { get; }

    public NotificationEventArgs(string department, string message, Priority priority)
    {
        Department = department;
        Message = message;
        Priority = priority;
    }
}

public interface INotificationPublisher
{
    event EventHandler<NotificationEventArgs> DetailedNotification;
}

public class NotificationSystem : INotificationPublisher
{
    public event EventHandler Notification;
    public event EventHandler<NotificationEventArgs> DetailedNotification;

    public void SendNotification(string message)
    {
        Console.WriteLine($"Attempting to send: {message}");
        OnNotification();
    }

    protected virtual void OnNotification()
    {
        Notification?.Invoke(this, EventArgs.Empty);
    }

    public void SendDetailedNotification(string dept, string msg, Priority priority)
    {
        Console.WriteLine($"Attempting to send detailed notification to {dept}: {msg}");
        OnDetailedNotification(dept, msg, priority);
    }

    protected virtual void OnDetailedNotification(string dept, string msg, Priority priority)
    {
        NotificationEventArgs args = new NotificationEventArgs(dept, msg, priority);
        DetailedNotification?.Invoke(this, args);
    }
}

public class UrgentNotificationSystem : INotificationPublisher
{
    public event EventHandler<NotificationEventArgs> DetailedNotification;

    protected virtual void OnUrgentNotification(string department, string message)
    {
        NotificationEventArgs args = new NotificationEventArgs(department, message, Priority.Urgent);
        DetailedNotification?.Invoke(this, args);
    }

    public void SendUrgentNotification(string department, string message)
    {
        Console.WriteLine($"Sending URGENT notification to {department}: {message}");
        OnUrgentNotification(department, message);
    }
}

public class EmailSubscriber
{
    public void HandleBasicNotification(object sender, EventArgs e)
    {
        Console.WriteLine("Email: Notification received");
    }

    public void HandleDetailedNotification(object sender, NotificationEventArgs e)
    {
        Console.WriteLine($"Email: [{e.Priority}] {e.Department} - {e.Message}");
    }
}

class Program
{
    static void Main()
    {
        // Basic event handling
        NotificationSystem notifier = new NotificationSystem();
        notifier.SendNotification("System startup complete");

        EmailSubscriber subscriber = new EmailSubscriber();

        Console.WriteLine("Corporate Notification System");

        notifier.Notification += subscriber.HandleBasicNotification;
        notifier.SendNotification("Test notification");

        // Detailed notifications with custom EventArgs
        notifier.DetailedNotification += subscriber.HandleDetailedNotification;
        notifier.SendDetailedNotification("IT", "Scheduled system update", Priority.Low);

        // Interface-based publisher
        UrgentNotificationSystem urgentSystem = new UrgentNotificationSystem();
        urgentSystem.DetailedNotification += subscriber.HandleDetailedNotification;
        urgentSystem.SendUrgentNotification("Security", "Unauthorized access detected");
    }
}