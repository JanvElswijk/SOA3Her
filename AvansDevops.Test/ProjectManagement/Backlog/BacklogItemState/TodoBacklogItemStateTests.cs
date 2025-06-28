using NUnit.Framework;
using System;
using AvansDevops.ProjectManagement;
using Moq;

[TestFixture]
public class TodoBacklogItemStateTests
{
    private BacklogItem _backlogItem;
    private IBacklogItemState _todoState;

    [SetUp]
    public void Setup()
    {
        _backlogItem = new BacklogItem("Test", "Desc", 3);
        _todoState = new TodoBacklogItemState(_backlogItem);
    }

    [Test]
    public void Complete_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _todoState.Complete());
        Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item in the Todo state."));
    }

    [Test]
    public void Approve_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _todoState.Approve());
        Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item in the Todo state."));
    }

    [Test]
    public void Reject_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _todoState.Reject());
        Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item in the Todo state."));
    }

    [Test]
    public void Start_WithoutDeveloper_ThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _todoState.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item in the Todo state without a developer assigned."));
    }

    [Test]
    public void Start_ChangesStateToDoing()
    {

        // Arrange
        var developer = new User("Dev", "dev@mail.com", UserRole.Developer);
        _backlogItem.SetUser(developer);


        Assert.DoesNotThrow(() => _todoState.Start());
        // Assert
        Assert.That(_backlogItem.State, Is.InstanceOf<DoingBacklogItemState>());

    }
}
