using AvansDevops.Notifications;
using AvansDevops.Notifications.Adapter;
using AvansDevops.ProjectManagement;
using Moq;

[TestFixture]
public class NotificationServiceTests
{

    //----------AddNotificationAdapter----------
    [Test]
    public void AddNotificationAdapter_AddsNewAdapter()
    {
        // Arrange
        var adapter = new Mock<INotificationAdapter>();
        var service = new NotificationService(adapter.Object);

        // Act
        service.AddNotificationAdapter(adapter.Object);

        var user = new User("Jan", "jan@example.com", UserRole.Tester);
        var backlogItem = new BacklogItem("Test", "Testdesc", 3);
        service.Update(user, backlogItem, "Test message");

        // Assert
        adapter.Verify(a => a.SendNotification(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void AddNotificationAdapter_DoesNotAddDuplicateAdapters()
    {
        // Arrange
        var adapter = new Mock<INotificationAdapter>();
        var service = new NotificationService(adapter.Object);

        service.AddNotificationAdapter(adapter.Object); // Proberen dezelfde opnieuw toe te voegen

        var user = new User("Jan", "jan@example.com", UserRole.Tester);
        var backlogItem = new BacklogItem("Test", "Testdesc", 3);

        // Act
        service.Update(user, backlogItem, "Test message");

        // Assert
        adapter.Verify(a => a.SendNotification(It.IsAny<string>()), Times.Once);
    }

    //----------Update----------
    [Test]
    public void Update_CallsAdapter()
    {
        // Arrange
        var mockAdapter = new Mock<INotificationAdapter>();
        var service = new NotificationService(mockAdapter.Object);

        var user = new User("Jan", "jan@example.com", UserRole.Tester);

        var backlogItem = new BacklogItem("Test", "Testdesc", 3);

        // Act
        service.Update(user, backlogItem, "Test message");

        // Assert
        mockAdapter.Verify(a => a.SendNotification(It.Is<string>(s => s.Contains("Jan"))), Times.Once);


    }

    [Test]
    public void Update_CallsSendNotification_OnEmailAdapter()
    {
        // Arrange
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var emailAdapter = new EmailAdapter();
        var service = new NotificationService(emailAdapter);
        var user = new User("Jan", "jan@example.com", UserRole.Tester);
        var backlogItem = new BacklogItem("Test", "Testdesc", 3);
        // Act
        service.Update(user, backlogItem, "Test message");
        // Assert
        var output = stringWriter.ToString();
        Assert.That(output, Does.Contain("Jan"));
        Assert.That(output, Does.Contain("Email Notification"));
    }

    [Test]
    public void Update_CallsSendNotification_OnSlackAdapter()
    {
        // Arrange
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var slackAdapter = new SlackAdapter();
        var service = new NotificationService(slackAdapter);
        var user = new User("Jan", "jan@example.com", UserRole.Tester);
        var backlogItem = new BacklogItem("Test", "Testdesc", 3);
        // Act
        service.Update(user, backlogItem, "Test message");

        // Assert
        var output = stringWriter.ToString();
        Assert.That(output, Does.Contain("Jan"));
        Assert.That(output, Does.Contain("Slack Notification"));
    }

    [Test]
    public void Update_CallsSendNotification_OnAllAdapters()
    {
        // Arrange
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var adapter1 = new EmailAdapter();
        var adapter2 = new SlackAdapter();

        var service = new NotificationService(adapter1);
        service.AddNotificationAdapter(adapter2);

        var user = new User("Jan", "jan@example.com", UserRole.Tester);

        var backlogItem = new BacklogItem("Test", "Testdesc", 3);

        // Act
        service.Update(user, backlogItem, "Test message");

        // Assert

        var output = stringWriter.ToString();
        Assert.That(output, Does.Contain("Jan"));
        Assert.That(output, Does.Contain("Email Notification"));
        Assert.That(output, Does.Contain("Slack Notification"));
    }

    [Test]
    public void Update_WithNoAdapters_DoesNotThrow()
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