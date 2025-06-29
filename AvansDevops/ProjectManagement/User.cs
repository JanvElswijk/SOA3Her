using AvansDevops.Notifications;
using AvansDevops.Notifications.Adapter;

namespace AvansDevops.ProjectManagement;

public class User : INotificationObserver
{
    public string Name;
    private string Email;
    private UserRole Role;
    public NotificationService _notificationService;


public User(){}

    public User(string name, string email, UserRole role)
    {
        Name = name;
        Email = email;
        Role = role;
        _notificationService = new NotificationService(new EmailAdapter());
    }

    public virtual UserRole GetRole()
    {
        return Role;
    }

    public virtual void Update(BacklogItem backlogItem, string message)
    {
        _notificationService.Update(this, backlogItem, message);
    }

    
}

public enum UserRole
{
    Developer,
    LeadDeveloper,
    Tester,
    ProjectManager,
    ScrumMaster,
    ProductOwner,
}
