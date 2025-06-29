using AvansDevops.DevOps.Test;

namespace AvansDevops.Test.DevOps.Test;

[TestFixture]
public class NUnitActivityTests
{
    [Test]
    public void RunTestsShouldReturnTrue()
    {
        // Arrange
        var activity = new NUnitActivity(true, "test.nunit.com/publish");

        // Act
        var result = activity.RunTests();

        // Assert
        Assert.That(result, Is.True);
    }
}