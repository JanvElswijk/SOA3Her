using NUnit.Framework;
using System;
using AvansDevops.ProjectManagement;
using Moq;


[TestFixture]
public class TestedBacklogItemStateTests
{
     private BacklogItem _backlogItem;
    private IBacklogItemState _testedState;

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

        _testedState = new TestedBacklogItemState(_backlogItem);
    }

    [Test]
    public void Complete_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testedState.Complete());
        Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is already tested."));
    }

    [Test]
    public void Approve_UserIsNotLeadDeveloper_ThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testedState.Approve());
        Assert.That(ex.Message, Is.EqualTo("Only lead developers can reject a backlog item that is tested."));
    }

    [Test]
    public void Reject_UserIsNotLeadDeveloper_ThrowsException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testedState.Reject());
        Assert.That(ex.Message, Is.EqualTo("Only lead developers can reject a backlog item that is tested."));
    }


    [Test]
    public void Reject_ChangesStateToTodo()
    {
           var developer = new User("Dev", "dev@mail.com", UserRole.LeadDeveloper);
        _backlogItem.SetUser(developer);
        
        // Assert
        Assert.DoesNotThrow(() => _testedState.Reject());
        Assert.That(_backlogItem._state, Is.InstanceOf<ReadyForTestingBacklogItemState>());

    }

    [Test]
    public void Start_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testedState.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already tested."));
    }
}
