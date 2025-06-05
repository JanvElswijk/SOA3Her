public class NotificationService : INotificationObserver
{
    private readonly List<INotificationAdapter> _notificationAdapters = new();

    public NotificationService(INotificationAdapter notificationAdapter)
    {
        _notificationAdapters.Add(notificationAdapter);
    }

    public void AddNotificationAdapter(INotificationAdapter notificationAdapter)
    {
        // Prevent adding an adapter of the same type more than once
        if (_notificationAdapters.Any(a => a.GetType() == notificationAdapter.GetType()))
        {
            return;
        }
        _notificationAdapters.Add(notificationAdapter);
    }

    public void Update(BacklogItem backlogItem, string message)
    {
        foreach (var _notificationAdapter in _notificationAdapters)
        {
            _notificationAdapter.SendNotification(
                $"Backlog item '{backlogItem.title}' has been updated: {message}. "
            );
        }
    }
}
