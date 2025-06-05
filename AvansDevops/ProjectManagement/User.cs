public class User : INotificationObserver
{
    private string Name;
    private string Email;
    private UserRole Role;

    public User(string name, string email, UserRole role)
    {
        Name = name;
        Email = email;
        Role = role;
    }

    public UserRole GetRole()
    {
        return Role;
    }

    public void Update(BacklogItem backlogItem, string message)
    {
        Console.WriteLine($"Notification for {Name}, ({Email}): {message}");
    }
}

public enum UserRole
{
    Developer,
    LeadDeveloper,
    Tester,
    ProjectManager,
    ProductOwner,
}
