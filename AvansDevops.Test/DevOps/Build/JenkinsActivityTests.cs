using AvansDevops.DevOps.Build;

namespace AvansDevops.Test.DevOps.Build;

[TestFixture]
public class JenkinsActivityTests
{
    [Test]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var activity = new JenkinsActivity();

        // Act
        var result = activity.Build();

        // Assert
        Assert.That(result, Is.True);
    }
}