public class User : INotificationObserver
{
    public string Name;
    private string Email;
    private UserRole Role;
    private NotificationService _notificationService;

    public User(string name, string email, UserRole role)
    {
        Name = name;
        Email = email;
        Role = role;
        _notificationService = new NotificationService(new EmailAdapter());        
    }

    public UserRole GetRole()
    {
        return Role;
    }

    public void Update(BacklogItem backlogItem, string message)
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
