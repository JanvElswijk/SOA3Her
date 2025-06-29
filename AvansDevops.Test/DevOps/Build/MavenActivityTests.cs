using AvansDevops.DevOps.Build;

namespace AvansDevops.Test.DevOps.Build;

[TestFixture]
public class MavenActivityTests
{
    [Test]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var activity = new MavenActivity();

        // Act
        var result = activity.Build();

        // Assert
        Assert.That(result, Is.True);
    }
}