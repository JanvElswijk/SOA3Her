public class EmailAdapter : INotificationAdapter
{
    public void SendNotification(string message)
    {
        // Implementation for sending a notification to Slack
        // This could involve using Slack's API to post a message to a channel
        Console.WriteLine($"Sending notification to Email: {message}");
    }
}
