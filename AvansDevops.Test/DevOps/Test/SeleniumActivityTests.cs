using AvansDevops.DevOps.Test;

namespace AvansDevops.Test.DevOps.Test;

[TestFixture]
public class SeleniumActivityTests
{
    [Test]
    public void RunTestsShouldReturnTrue()
    {
        // Arrange
        var activity = new SeleniumActivity(true, "test.selenium.com/publish");

        // Act
        var result = activity.RunTests();

        // Assert
        Assert.That(result, Is.True);
    }
}