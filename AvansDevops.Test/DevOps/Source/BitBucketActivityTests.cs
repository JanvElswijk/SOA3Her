using AvansDevops.DevOps.Source;

namespace AvansDevops.Test.DevOps.Source;

[TestFixture]
public class BitBucketActivityTests
{
    [Test]
    public void GetSourceCodeShouldReturnTrue()
    {
        // Arrange
        var activity = new BitBucketActivity("bitbucket.com/repository/test");

        // Act
        var result = activity.GetSourceCode();

        // Assert
        Assert.That(result, Is.True);
    }
}