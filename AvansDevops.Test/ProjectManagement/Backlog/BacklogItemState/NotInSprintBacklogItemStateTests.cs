using AvansDevops.ProjectManagement.Backlog.BacklogItemState;

namespace AvansDevops.Test.ProjectManagement.Backlog.BacklogItemState;

[TestFixture]
public class NotInSprintBacklogItemStateTests
{
    private IBacklogItemState _state;

    [SetUp]
    public void SetUp()
    {
        _state = new NotInSprintBacklogItemState();
    }

    [Test]
    public void Complete_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _state.Complete());
        Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is not in the sprint."));
    }

    [Test]
    public void Reject_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _state.Reject());
        Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item that is not in the sprint."));
    }

    [Test]
    public void Approve_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _state.Approve());
        Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item that is not in the sprint."));
    }

    [Test]
    public void Start_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is not in the sprint."));
    }
}