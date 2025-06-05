public class NotificationService : IObserver
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

        /// <summary>
        /// Sends a notification with the specified message.
        /// </summary>
        /// <param name="message">The message to be sent in the notification.</param> 
        public void Update(BacklogItem backlogItem)
        {
            foreach (var _notificationAdapter in _notificationAdapters)
            {
                _notificationAdapter.SendNotification(
                    $"Backlog item '{backlogItem.title}' has been updated. " +
                    $"Status: {backlogItem.status}, Story Points: {backlogItem.storyPoints}. " +
                    $"Description: {backlogItem.description}");
            }
        }
    }