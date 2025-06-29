using NUnit.Framework;
using System;
using System.Linq;
using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Forum;

[TestFixture]
public class ForumTests
{
    private Forum _forum;
    private BacklogItem _backlogItem;

    [SetUp]
    public void SetUp()
    {
        _forum = new Forum();
        _backlogItem = new BacklogItem("Test Item", "Test Description", 5);
    }

    // CreateThread Tests (CC = 3)
    [Test]
    public void CreateThread_WithValidBacklogItem_CreatesThread()
    {
        // Act
        _forum.CreateThread(_backlogItem);

        // Assert
        Assert.That(_forum._threads.Count, Is.EqualTo(1));
        Assert.That(_forum._threads[0].BacklogItem, Is.EqualTo(_backlogItem));
    }

    [Test]
    public void CreateThread_WithNullBacklogItem_ThrowsArgumentNullException()
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => _forum.CreateThread(null));
        Assert.That(ex.ParamName, Is.EqualTo("backlogItem"));
        Assert.That(ex.Message, Does.Contain("Backlog item cannot be null."));
    }

    [Test]
    public void CreateThread_WithExistingBacklogItem_ThrowsInvalidOperationException()
    {
        // Arrange
        _forum.CreateThread(_backlogItem);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => _forum.CreateThread(_backlogItem));
        Assert.That(ex.Message, Is.EqualTo("A thread for this backlog item already exists."));
    }

    // GetThreadByBacklogItem Tests (CC = 3)
    [Test]
    public void GetThreadByBacklogItem_WithExistingThread_ReturnsThread()
    {
        // Arrange
        _forum.CreateThread(_backlogItem);

        // Act
        var thread = _forum.GetThreadByBacklogItem(_backlogItem);

        // Assert
        Assert.That(thread, Is.Not.Null);
        Assert.That(thread.BacklogItem, Is.EqualTo(_backlogItem));
    }

    [Test]
    public void GetThreadByBacklogItem_WithNullBacklogItem_ThrowsArgumentNullException()
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => _forum.GetThreadByBacklogItem(null));
        Assert.That(ex.ParamName, Is.EqualTo("backlogItem"));
        Assert.That(ex.Message, Does.Contain("Backlog item cannot be null."));
    }

    [Test]
    public void GetThreadByBacklogItem_WithNonExistingThread_ThrowsInvalidOperationException()
    {
        // Arrange
        var nonExistingItem = new BacklogItem("Non-existing", "Description", 3);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => _forum.GetThreadByBacklogItem(nonExistingItem));
        Assert.That(ex.Message, Is.EqualTo("No thread found for the specified backlog item."));
    }
}