using AvansDevops.DevOps.Utility;

namespace AvansDevops.Test.DevOps.Utility;

[TestFixture]
public class CliActivityTests
{
    [Test]
    public void RunUtilityShouldReturnTrue()
    {
        // Arrange
        var activity = new CliActivity("echo 'test'");

        // Act
        var result = activity.RunUtility();

        // Assert
        Assert.That(result, Is.True);
    }
}