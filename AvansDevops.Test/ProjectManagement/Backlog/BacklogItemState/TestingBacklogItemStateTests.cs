using NUnit.Framework;
using System;
using AvansDevops.ProjectManagement;

[TestFixture]
public class TestingBacklogItemStateTests
{
    private BacklogItem _backlogItem;
    private IBacklogItemState _doneState;

    [SetUp]
    public void Setup()
    {
        _backlogItem = new BacklogItem("Test", "Desc", 3);
        _doneState = new TestingBacklogItemState(_backlogItem);
    }

    [Test]
    public void Complete_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Complete());
        Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is already done."));
    }

    [Test]
    public void Approve_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Approve());
        Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item that is already done."));
    }

    [Test]
    public void Reject_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Reject());
        Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item that is already done."));
    }

    [Test]
    public void Start_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _doneState.Start());
        Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already done."));
    }
}
