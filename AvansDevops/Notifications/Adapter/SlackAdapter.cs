
namespace AvansDevops.Notifications.Adapter;
public class SlackAdapter : INotificationAdapter
{
    public virtual void SendNotification(string message)
    {
        // Implementation for sending a notification to Slack
        // This could involve using Slack's API to post a message to a channel
        Console.WriteLine($"[NOTIFICATION] Slack Notification: {message}");
    }
}
