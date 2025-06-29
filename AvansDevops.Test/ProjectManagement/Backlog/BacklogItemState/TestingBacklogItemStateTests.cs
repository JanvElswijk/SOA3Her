using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Backlog;
using AvansDevops.ProjectManagement.Backlog.BacklogItemState;
using AvansDevops.ProjectManagement.Sprint;
using Moq;

namespace AvansDevops.Test.ProjectManagement.Backlog.BacklogItemState;

[TestFixture]
public class TestingBacklogItemStateTests
{
    private BacklogItem _backlogItem;
    private IBacklogItemState _testingState;

    private TextWriter _originalConsoleOut;
    private StringWriter _consoleOutput;

    [SetUp]
    public void Setup()
    {
        _originalConsoleOut = Console.Out;
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);

        _backlogItem = new BacklogItem("Test", "Desc", 3);

        var project = new AvansDevops.ProjectManagement.Project.Project("Test Project", null, new List<User>(), null);
        var backlog = new AvansDevops.ProjectManagement.Backlog.Backlog();
        backlog.AddBacklogItem(_backlogItem);
        var leadDeveloper = new User("Lead", "lead@test.com", UserRole.LeadDeveloper);
        var testers = new List<User>();
        var scrumMaster = new User("Scrum", "scrum@test.com", UserRole.ScrumMaster);
        var mockStrategy = new Mock<ISprintStrategy>();

        var sprint = new AvansDevops.ProjectManagement.Sprint.Sprint(project, backlog, leadDeveloper, testers, scrumMaster, mockStrategy.Object, null);
        _backlogItem.SetSprint(sprint);

        _testingState = new TestingBacklogItemState(_backlogItem);
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(_originalConsoleOut);
        _consoleOutput.Dispose();
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
        Assert.That(_backlogItem.State, Is.InstanceOf<TestedBacklogItemState>());

    }


    [Test]
    public void Reject_ChangesStateToTodo()
    {
        var developer = new User("Dev", "dev@mail.com", UserRole.Developer);
        _backlogItem.SetUser(developer);

        // Assert
        Assert.DoesNotThrow(() => _testingState.Reject());

        Assert.That(_backlogItem.State, Is.InstanceOf<TodoBacklogItemState>());
 
    }


    [Test]
    public void Start_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _testingState.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already in the Testing state."));
    }
}