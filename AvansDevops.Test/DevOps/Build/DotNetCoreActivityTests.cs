using AvansDevops.DevOps.Build;

namespace AvansDevops.Test.DevOps.Build;

[TestFixture]
public class DotNetCoreActivityTests
{
    [Test]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var activity = new DotNetCoreActivity();

        // Act
        var result = activity.Build();

        // Assert
        Assert.That(result, Is.True);
    }
}