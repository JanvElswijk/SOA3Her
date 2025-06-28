using NUnit.Framework;
using System;
using AvansDevops.ProjectManagement;
using Moq;

[TestFixture]
public class TestingBacklogItemStateTests
{
    private BacklogItem _backlogItem;
    private IBacklogItemState _testingState;

    [SetUp]
    public void Setup()
    {
        _backlogItem = new BacklogItem("Test", "Desc", 3);

        var project = new Project("Test Project", null, new List<User>(), null);
        var backlog = new Backlog();
        backlog.AddBacklogItem(_backlogItem);
        var leadDeveloper = new User("Lead", "lead@test.com", UserRole.LeadDeveloper);
        var testers = new List<User>();
        var scrumMaster = new User("Scrum", "scrum@test.com", UserRole.ScrumMaster);
        var mockStrategy = new Mock<ISprintStrategy>();

        var sprint = new Sprint(project, backlog, leadDeveloper, testers, scrumMaster, mockStrategy.Object, null);
        _backlogItem.SetSprint(sprint);

        

        _testingState = new TestingBacklogItemState(_backlogItem);
    }

    [Test]
    public void Complete_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testingState.Complete());
        Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is in the Testing state."));
    }

    [Test]
    public void Approve_ChangesStateToTodo()
    {
           var developer = new User("Dev", "dev@mail.com", UserRole.Developer);
        _backlogItem.SetUser(developer);
        
        
        // Assert
        Assert.DoesNotThrow(() => _testingState.Approve());
        Assert.That(_backlogItem._state, Is.InstanceOf<TestedBacklogItemState>());

    }


    [Test]
    public void Reject_ChangesStateToTodo()
    {
           var developer = new User("Dev", "dev@mail.com", UserRole.Developer);
        _backlogItem.SetUser(developer);

        // Assert
        Assert.DoesNotThrow(() => _testingState.Reject());

        Assert.That(_backlogItem._state, Is.InstanceOf<TodoBacklogItemState>());
 
    }


    [Test]
    public void Start_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testingState.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already in the Testing state."));
    }
}
