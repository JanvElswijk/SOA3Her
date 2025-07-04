using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Backlog;
using AvansDevops.ProjectManagement.Backlog.BacklogItemState;

namespace AvansDevops.Test.ProjectManagement.Backlog.BacklogItemState;

[TestFixture]
public class ReadyForTestingBacklogItemStateTests
{
    private BacklogItem _backlogItem;
    private IBacklogItemState _readyForTestingState;

    [SetUp]
    public void Setup()
    {
        _backlogItem = new BacklogItem("Test", "Desc", 3);

        _readyForTestingState = new ReadyForTestingBacklogItemState(_backlogItem);
    }

    [Test]
    public void Complete_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _readyForTestingState.Complete());
        Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is ready for testing."));
    }

    [Test]
    public void Approve_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _readyForTestingState.Approve());
        Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item that is ready for testing."));
    }

    [Test]
    public void Reject_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _readyForTestingState.Reject());
        Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item that is ready for testing."));
    }

    [Test] 
    public void Start_ThrowsInvalidOperationException_WhenNoTesterAssigned()
    {
        // Arrange
        var user = new User("Developer", "dev@mail.com", UserRole.Developer);
        _backlogItem.SetUser(user);

        var ex = Assert.Throws<InvalidOperationException>(() => _readyForTestingState.Start());
        Assert.That(ex.Message, Is.EqualTo("Only testers can start a backlog item that is ready for testing."));
    }
    

    [Test]
    public void Start_ChangesStateToTesting()
    {
        var developer = new User("Dev", "dev@mail.com", UserRole.Tester);
        _backlogItem.SetUser(developer);
        
        Assert.DoesNotThrow(() => _readyForTestingState.Start());

        // Assert
        Assert.That(_backlogItem.State, Is.InstanceOf<TestingBacklogItemState>());
    }
}