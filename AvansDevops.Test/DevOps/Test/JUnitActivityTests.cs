using AvansDevops.DevOps.Test;

namespace AvansDevops.Test.DevOps.Test;

[TestFixture]
public class JUnitActivityTests
{
    [Test]
    public void RunTestsShouldReturnTrue()
    {
        // Arrange
        var activity = new JUnitActivity(true, "test.junit.com/publish");

        // Act
        var result = activity.RunTests();

        // Assert
        Assert.That(result, Is.True);
    }
}