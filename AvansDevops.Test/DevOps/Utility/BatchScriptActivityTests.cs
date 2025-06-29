using AvansDevops.DevOps.Utility;

namespace AvansDevops.Test.DevOps.Utility;

[TestFixture]
public class BatchScriptActivityTests
{
    [Test]
    public void RunUtilityShouldReturnTrue()
    {
        // Arrange
        var activity = new BatchScriptActivity("test.bat");

        // Act
        var result = activity.RunUtility();

        // Assert
        Assert.That(result, Is.True);
    }
}