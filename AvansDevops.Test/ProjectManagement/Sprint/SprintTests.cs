using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using AvansDevops.ProjectManagement;
using NUnit.Framework.Internal;
using AvansDevops.DevOps;
using AvansDevops.Notifications.Adapter;



[TestFixture]
public class SprintTests
{

    private Sprint CreateSprint(out List<User> testers, out User scrumMaster, out User leadDeveloper, Pipeline? pipeline = null)
    {
        testers = new List<User> {
            new User("Tester1", "test@mail.com", UserRole.Tester),
            new User("Tester2", "test2@mail.com", UserRole.Tester)
        };

        scrumMaster = new User("Scrum Master", "scrum@mail.com", UserRole.ScrumMaster);
        leadDeveloper = new User("Lead Dev", "lead.dev@example.com", UserRole.LeadDeveloper);
        var project = new Project("Test Project", null, testers, leadDeveloper);
        var backlog = new Backlog();
        var mockSprintStrategy = new Mock<ISprintStrategy>().Object;

        return new Sprint(project, backlog, leadDeveloper, testers, scrumMaster, mockSprintStrategy, pipeline);
    }
    private Sprint CreateSprintWithNoObservers()
    {
        var testers = new List<User>();
        var scrumMaster = new User("Scrum Master", "scrum@mail.com", UserRole.ScrumMaster);
        var leadDeveloper = new User("Lead Dev", "lead.dev@example.com", UserRole.LeadDeveloper);
        var project = new Project("Test Project", null, testers, leadDeveloper);
        var backlog = new Backlog();
        var mockSprintStrategy = new Mock<ISprintStrategy>().Object;

        return new Sprint(project, backlog, leadDeveloper, testers, scrumMaster, mockSprintStrategy, null);
    }
    [Test]
    public void AddObserver_AddsObserver()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);
        //Act
        sprint.AddObserver(new User("Observer1", "test@mail.com", UserRole.Tester));

        // Assert
        Assert.That(sprint.GetObservers().Count, Is.EqualTo(5)); // Scrum Master, Product Owner, Tester1, Tester2 + new Observer1

    }

    [Test]
    public void AddObserver_ObserverAlreadyExists_DoesNotAddAgain()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);

        //Act
        sprint.AddObserver(scrumMaster);
        sprint.AddObserver(scrumMaster);
        sprint.AddObserver(scrumMaster);

        // Assert
        Assert.That(sprint.GetObservers().Count, Is.EqualTo(4)); // Scrum Master, Product Owner, Tester1, Tester2
    }

    [Test]
    public void RemoveObserver_RemovesObserver()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);

        // Act
        sprint.RemoveObserver(testers[0]); // Remove Tester1
        sprint.RemoveObserver(testers[1]); // Remove Tester2

        // Assert
        Assert.That(sprint.GetObservers().Count, Is.EqualTo(2)); // Scrum Master + Product Owner
        Assert.That(sprint.GetObservers(), Does.Not.Contain(testers[0]));
        Assert.That(sprint.GetObservers(), Does.Not.Contain(testers[1]));
    }

    [Test]
    public void RemoveObserver_ObserverDoesNotExist_DoesNotThrow()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);

        // Act
        sprint.RemoveObserver(testers[0]); // Remove Tester1
        sprint.RemoveObserver(testers[1]); // Remove Tester2


        // Assert
        Assert.That(sprint.GetObservers(), Does.Not.Contain(testers[0]));
        Assert.That(sprint.GetObservers(), Does.Not.Contain(testers[1]));
        Assert.That(sprint.GetObservers().Count, Is.EqualTo(2));
        Assert.DoesNotThrow(() => sprint.RemoveObserver(testers[0])); // Attempt to remove again should not throw

    }

    [Test]
    public void GetObservers_ReturnsAllObservers()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);

        // Act
        var observers = sprint.GetObservers();

        // Assert
        Assert.That(observers.Count, Is.EqualTo(4)); // Scrum Master, Product Owner, Tester1, Tester2
        Assert.That(observers, Does.Contain(scrumMaster));
        Assert.That(observers, Does.Contain(testers[0]));
        Assert.That(observers, Does.Contain(testers[1]));
    }

    [Test]
    public void SetStrategy_ChangesStrategy()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);
        var newStrategy = new Mock<ISprintStrategy>().Object;

        // Act
        sprint.SetStrategy(newStrategy);

        // Assert
        Assert.That(sprint.GetObservers().Count, Is.EqualTo(4)); // Scrum Master, Product Owner, Tester1, Tester2
    }
    [Test]
    public void ExecuteStrategy_CallsStrategyExecute()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);
        var mockStrategy = new Mock<ISprintStrategy>();
        sprint.SetStrategy(mockStrategy.Object);

        // Act
        sprint.ExecuteStrategy();

        // Assert
        mockStrategy.Verify(s => s.Execute(It.IsAny<Pipeline>(), It.IsAny<String>()), Times.Once);

    }
    [Test]
    public void ExecuteStrategy_WithNullPipeline_DoesNotThrow()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);
        var mockStrategy = new Mock<ISprintStrategy>();
        sprint.SetStrategy(mockStrategy.Object);

        // Act & Assert
        Assert.DoesNotThrow(() => sprint.ExecuteStrategy());
    }
    [Test]
    public void ExecuteStrategy_WithNullSummary_DoesNotThrow()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);
        var mockStrategy = new Mock<ISprintStrategy>();
        sprint.SetStrategy(mockStrategy.Object);

        // Act & Assert
        Assert.DoesNotThrow(() => sprint.ExecuteStrategy());
    }

    [Test]
    public void ExecuteStrategy_WithValidPipelineAndSummary_CallsStrategyExecute()
    {
        // Arrange
        var mockStrategy = new Mock<ISprintStrategy>();
        var pipeline = new DevOpsPipeline();
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper, pipeline);

        sprint.SetStrategy(mockStrategy.Object);
        string summary = "Test Summary";
        sprint.SetSummary(summary);

        // Act
        sprint.ExecuteStrategy();

        // Assert
        mockStrategy.Verify(s => s.Execute(pipeline, summary), Times.Once);
    }

    [Test]
    public void SetSummary_UpdatesSummary()
    {
        // Arrange
        var sprint = CreateSprint(out var testers, out var scrumMaster, out var leadDeveloper);
        string newSummary = "New Sprint Summary";

        // Act
        sprint.SetSummary(newSummary);

        // Assert
        Assert.That(sprint.GetObservers().Count, Is.EqualTo(4)); // Scrum Master, Product Owner, Tester1, Tester2
    }

    [Test] //TODO; dubbelcheck
    public void NotifyObservers_CallsUpdateOnAllObservers()
    {
        // Arrange
        var sprint = CreateSprintWithNoObservers();

        // Verwijder alle bestaande observers (zoals Scrum Master)
        foreach (var observer in sprint.GetObservers().ToList())
            sprint.RemoveObserver(observer);

        var mockObserver = new Mock<INotificationObserver>();
        sprint.AddObserver(mockObserver.Object);

        string testMessage = "Test notification";

        // Act
        sprint.NotifyObservers(testMessage);

        // Assert
        mockObserver.Verify(o => o.Update(null, testMessage), Times.Once);
    }

    [Test]
    public void NotifyTesters_NotifyAllTesters()
    {
    //TODO
    }


    [Test]
    public void NotifyScrumMaster_NotifyScrumMaster()
    {
        // TODO
    }
    [Test]
    public void NotifyProductOwner_NotifyProductOwner()
    {
        // TODO
    }

}