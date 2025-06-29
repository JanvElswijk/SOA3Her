using AvansDevops.ProjectManagement.Backlog;

namespace AvansDevops.Notifications.Adapter;

public interface INotificationObserver
{
    public void Update(BacklogItem? backlogItem, string message);
}
