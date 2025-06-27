using NUnit.Framework;
using System;
using System.Collections.Generic;
using AvansDevops.ProjectManagement;
using Moq;

[TestFixture]
public class DoingBacklogItemStateTests
{

    
    private BacklogItem _backlogItem;
    private IBacklogItemState _doneState;

    [SetUp]
    public void Setup()
    {
        _backlogItem = new BacklogItem("Test", "Desc", 3);
       var mockAdapter = new Mock<ISCMAdapter>();
        var service = new SCMService(mockAdapter.Object);
        var project = new Project("Test Project", service, new List<User>(), null);
        var backlog = new Backlog();
        backlog.AddBacklogItem(_backlogItem);
        var leadDeveloper = new User("Lead", "lead@test.com", UserRole.LeadDeveloper);
        var testers = new List<User>();
        var scrumMaster = new User("Scrum", "scrum@test.com", UserRole.ScrumMaster);
        var mockStrategy = new Mock<ISprintStrategy>();

        var sprint = new Sprint(project, backlog, leadDeveloper, testers, scrumMaster, mockStrategy.Object, null);
        _backlogItem.SetSprint(sprint);

        _doneState = new DoingBacklogItemState(_backlogItem);
    }

        [Test]
    public void Complete_ChangesStateToReadyForTesting()
    {
        // Act
        Assert.DoesNotThrow(() => _doneState.Complete());

        // Assert
        Assert.That(_backlogItem._state, Is.InstanceOf<ReadyForTestingBacklogItemState>());
    }


    [Test]
    public void Approve_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Approve());
        Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item that is in progress."));
    }

    [Test]
    public void Reject_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Reject());
        Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item that is in progress."));
    }

    [Test]
    public void Start_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is in progress."));
    }
}
