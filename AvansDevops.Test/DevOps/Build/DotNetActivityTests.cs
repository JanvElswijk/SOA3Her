using AvansDevops.DevOps.Build;

namespace AvansDevops.Test.DevOps.Build;

[TestFixture]
public class DotNetActivityTests
{
    [Test]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var activity = new DotNetActivity();

        // Act
        var result = activity.Build();

        // Assert
        Assert.That(result, Is.True);
    }
}