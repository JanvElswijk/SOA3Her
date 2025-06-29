using AvansDevops.DevOps.Deploy;

namespace AvansDevops.Test.DevOps.Deploy;

[TestFixture]
public class AWSActivityTests
{
    [Test]
    public void DeployShouldReturnTrue()
    {
        // Arrange
        var activity = new AWSActivity("aws.com/test");

        // Act
        var result = activity.Deploy();

        // Assert
        Assert.That(result, Is.True);
    }
}