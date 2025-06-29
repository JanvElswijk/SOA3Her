using AvansDevops.DevOps.Deploy;

namespace AvansDevops.Test.DevOps.Deploy;

[TestFixture]
public class AzureActivityTests
{
    [Test]
    public void DeployShouldReturnTrue()
    {
        // Arrange
        var activity = new AzureActivity("azure.com/test");

        // Act
        var result = activity.Deploy();

        // Assert
        Assert.That(result, Is.True);
    }
}