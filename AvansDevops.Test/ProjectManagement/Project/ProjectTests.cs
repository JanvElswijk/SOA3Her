using NUnit.Framework;
using System.Collections.Generic;
using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Project;
using Moq;
using AvansDevops.ProjectManagement.Forum;

[TestFixture]
public class ProjectTests
{
    private SCMService _scmService;
    private List<User> _developers;
    private User _productOwner;
    private Project _project;

    [SetUp]
    public void SetUp()
    {
      var mockSCMAdapter = new Mock<ISCMAdapter>();
    _scmService = new SCMService(mockSCMAdapter.Object);
        _developers = new List<User>
        {
            new User("john", "john@mail.com", UserRole.Developer),
            new User("jane", "jane@mail.com", UserRole.Developer)
        };
        _productOwner = new User("po", "po@mail.com", UserRole.ProductOwner);
        _project = new Project("Test Project", _scmService, _developers, _productOwner);
    }

    [Test]
    public void Constructor_InitializesProjectWithGivenParameters()
    {
        Assert.That(_project.Title, Is.EqualTo("Test Project"));
        Assert.That(_project.Developers, Is.EqualTo(_developers));
        Assert.That(_project._productOwner, Is.EqualTo(_productOwner));
    }

    [Test]
    public void AddBacklogItem_AddsItemToBacklog()
    {
        var backlogItem = new BacklogItem("Test Item", "Description", 1);
        _project.AddBacklogItem(backlogItem);

        Assert.That(_project._backlog._items, Contains.Item(backlogItem));
        Assert.That(_project._backlog._items.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddThread_CreatesThreadInForum()
    {
        var backlogItem = new BacklogItem("Test Item", "Description", 1);
        _project.AddThread(backlogItem);

        Assert.That(_project._forum._threads.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddDeveloper_AddsDeveloperToProject()
    {
        //Arrange
        var newDeveloper = new User("newDev", "new@mail.com", UserRole.Developer);

        //Act
        _project.AddDeveloper(newDeveloper);

        //Assert
        Assert.That(_project.Developers, Contains.Item(newDeveloper));
        Assert.That(_project.Developers.Count, Is.EqualTo(3));

    }

    [Test]
    public void RemoveDeveloper_RemovesDeveloperFromProject()
    {
        //Arrange
        var developerToRemove = _developers[0];

        //Act
        _project.RemoveDeveloper(developerToRemove);

        //Assert
        Assert.That(_project.Developers, Does.Not.Contain(developerToRemove));
        Assert.That(_project.Developers.Count, Is.EqualTo(1));
    }

    [Test]
    public void StartNewSprint_CreatesNewSprint()
    {
        // Arrange
        var leadDeveloper = _developers[0];
        var testers = new List<User> { _developers[1] };
        var scrumMaster = new User("scrumMaster", "scrum@mail.com", UserRole.ScrumMaster);
        var strategy = new Mock<ISprintStrategy>().Object;

        //Act
        _project.StartNewSprint(leadDeveloper, testers, scrumMaster, strategy, null);

        //Assert
        Assert.That(_project._currentSprint, Is.Not.Null);
    }

    [Test]
    public void FinishSprint_ExecutesStrategyAndSetsCurrentSprintToNull()
    {
        // Arrange
        var leadDeveloper = _developers[0];
        var testers = new List<User> { _developers[1] };
        var scrumMaster = new User("scrumMaster", "scrum@mail.com", UserRole.ScrumMaster);
        var strategy = new Mock<ISprintStrategy>();

        //Assert
        _project.StartNewSprint(leadDeveloper, testers, scrumMaster, strategy.Object, null);

        _project.FinishSprint();

        //Assert
        Assert.That(_project._currentSprint, Is.Null);
        strategy.Verify(s => s.Execute(null, null), Times.Once, "Expected the sprint strategy to be executed once when finishing the sprint.");
    }

    [Test]
    public void MoveBacklogItemToSprint_ThrowsExceptionIfItemNotInBacklog()
    {
        // Arrange
        var backlogItem = new BacklogItem("Non-existent Item", "Description", 1);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _project.MoveBacklogItemToSprint(backlogItem), "Backlog item does not exist in the backlog.");
    }

    [Test]
    public void MoveBacklogItemToSprint_ThrowsExceptionIfNoActiveSprint()
    {
        // Arrange
        var backlogItem = new BacklogItem("Test Item", "Description", 1);
        _project.AddBacklogItem(backlogItem);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _project.MoveBacklogItemToSprint(backlogItem), "No active sprint to move backlog item to.");
    }

    [Test]
    public void MoveBacklogItemToSprint_MovesItemToCurrentSprint()
    {
        // Arrange
        var backlogItem = new BacklogItem("Test Item", "Description", 1);
        _project.AddBacklogItem(backlogItem);

        var leadDeveloper = _developers[0];
        var testers = new List<User> { _developers[1] };
        var scrumMaster = new User("scrumMaster", "scrum@mail.com", UserRole.ScrumMaster);
        var strategy = new Mock<ISprintStrategy>().Object;
        _project.StartNewSprint(leadDeveloper, testers, scrumMaster, strategy, null);
        // Act
        _project.MoveBacklogItemToSprint(backlogItem);
        // Assert
        Assert.That(_project._currentSprint._backlogItems._items, Contains.Item(backlogItem));
        Assert.That(_project._backlog._items, Does.Not.Contain(backlogItem));
    }
}
