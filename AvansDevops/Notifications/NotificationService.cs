using AvansDevops.Notifications.Adapter;
using AvansDevops.ProjectManagement;

namespace AvansDevops.Notifications;
public class NotificationService
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

    public void Update(User user, BacklogItem backlogItem, string message)
    {
        foreach (var _notificationAdapter in _notificationAdapters)
        {
            //maybe remove
            _notificationAdapter.SendNotification(
                $"{user.Name} has been notified"
            );
        }
    }
}
