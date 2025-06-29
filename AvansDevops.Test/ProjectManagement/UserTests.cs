using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Backlog;

namespace AvansDevops.Test.ProjectManagement;

[TestFixture]
public class UserTests
{
    [Test]
    public void UserConstructor_InitializesUserWithGivenParameters()
    {
        // Arrange
        string name = "John Doe";
        string email = "john@mail.com";
        UserRole role = UserRole.Developer;
        // Act
        User user = new User(name, email, role);
        // Assert
        Assert.That(user.Name, Is.EqualTo(name));
        Assert.That(user.GetRole(), Is.EqualTo(role));
    }

    [Test]
    public void GetRole_ReturnsUserRole()
    {
        // Arrange
        User user = new User("Jane Doe", "john@mail.com", UserRole.Tester);
        // Act
        UserRole role = user.GetRole();
        // Assert
        Assert.That(role, Is.EqualTo(UserRole.Tester));
    }
    [Test]
    public void Update_CallsNotificationServiceUpdate()
    {
        // Arrange
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        
        var user = new User("John Doe", "john@mail.com", UserRole.Developer);
        var backlogItem = new BacklogItem("Test Item", "Description", 1);
        string message = "Test message";
    
        // Act
        user.Update(backlogItem, message);
    
        // Assert
        var output = stringWriter.ToString();
        Assert.That(output, Does.Contain("John Doe"));
        Assert.That(output, Does.Contain("Email Notification"));
    }
}