using AvansDevops.ProjectManagement.Backlog;

namespace AvansDevops.Test.ProjectManagement.Backlog;

[TestFixture]
public class BacklogTests
{
    [Test] 
    public void Constructor_InitializesEmptyBacklog()
    {
        // Arrange & Act
        var backlog = new AvansDevops.ProjectManagement.Backlog.Backlog();

        // Assert
        Assert.That(backlog._items, Is.Not.Null);
        Assert.That(backlog._items, Is.Empty);
    }

    [Test]
    public void AddBacklogItem_AddsItem_WhenNotExists()
    {
        // Arrange
        var backlog = new AvansDevops.ProjectManagement.Backlog.Backlog();
        var item = new BacklogItem("Test", "desc", 1);

        // Act
        backlog.AddBacklogItem(item);

        // Assert
        Assert.That(backlog._items, Contains.Item(item));
    }

    [Test]
    public void AddBacklogItem_Throws_WhenItemAlreadyExists()
    {
        // Arrange
        var backlog = new AvansDevops.ProjectManagement.Backlog.Backlog();

        var item = new BacklogItem("Test", "desc", 1);
        backlog.AddBacklogItem(item);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => backlog.AddBacklogItem(item));
    }

}