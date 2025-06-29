using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Backlog;
using AvansDevops.ProjectManagement.Backlog.BacklogItemState;
using AvansDevops.ProjectManagement.Forum;

namespace AvansDevops.Test.ProjectManagement.Forum;

[TestFixture]
public class MessageThreadTests
{
    private BacklogItem _backlogItem;
    private MessageThread _messageThread;
    private User _testUser;

    [SetUp]
    public void SetUp()
    {
        _backlogItem = new BacklogItem("Test Item", "Test Description", 5);
        _messageThread = new MessageThread(_backlogItem);
        _testUser = new User("Test User", "test@example.com", UserRole.Developer);
        
        // Add initial message to avoid empty dictionary issue
        _messageThread._messages.Add(1, new Message("Initial", _testUser));
    }

    // AddMessage Tests (CC = 2)
    [Test]
    public void AddMessage_WithValidMessage_AddsMessage()
    {
        // Arrange
        var message = new Message("Test message", _testUser);

        // Act
        _messageThread.AddMessage(message);

        // Assert
        var result = _messageThread.ToString();
        Assert.That(result, Does.Contain("Test message"));
    }

    [Test]
    public void AddMessage_WhenBacklogItemIsDone_ThrowsException()
    {
        // Arrange
        _backlogItem.ChangeState(new DoneBacklogItemState(_backlogItem));
        var message = new Message("Test message", _testUser);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => _messageThread.AddMessage(message));
        Assert.That(ex.Message, Is.EqualTo("Cannot add messages to a thread of a done backlog item or a locked thread."));
    }

    [Test]
    public void AddMessage_WhenThreadIsLocked_ThrowsException()
    {
        // Arrange
        _messageThread.LockThread();
        var message = new Message("Test message", _testUser);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => _messageThread.AddMessage(message));
        Assert.That(ex.Message, Is.EqualTo("Cannot add messages to a thread of a done backlog item or a locked thread."));
    }

    // LockThread Tests (CC = 1)
    [Test]
    public void LockThread_SetsLockedToTrue()
    {
        // Act
        _messageThread.LockThread();

        // Assert
        var result = _messageThread.ToString();
        Assert.That(result, Does.Contain("Thread is locked."));
    }

    // UnlockThread Tests (CC = 1)
    [Test]
    public void UnlockThread_SetsLockedToFalse()
    {
        // Arrange
        _messageThread.LockThread();

        // Act
        _messageThread.UnlockThread();

        // Assert
        var result = _messageThread.ToString();
        Assert.That(result, Does.Contain("Thread is open for new messages."));
    }

    // ToString Tests (CC = 1)
    [Test]
    public void ToString_WhenLocked_ShowsLockedMessage()
    {
        // Arrange
        _messageThread.LockThread();

        // Act
        var result = _messageThread.ToString();

        // Assert
        Assert.That(result, Does.Contain("Thread is locked."));
        Assert.That(result, Does.Contain("Test Item"));
    }

    [Test]
    public void ToString_WhenUnlocked_ShowsOpenMessage()
    {
        // Act
        var result = _messageThread.ToString();

        // Assert
        Assert.That(result, Does.Contain("Thread is open for new messages."));
        Assert.That(result, Does.Contain("Test Item"));
    }
}