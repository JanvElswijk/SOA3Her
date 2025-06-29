using AvansDevops.DevOps.Package;

namespace AvansDevops.Test.DevOps.Package;

[TestFixture]
public class NpmActivityTests
{
    [Test]
    public void GetPackageShouldReturnTrue()
    {
        // Arrange
        var activity = new NpmActivity("npmjs.com/test");

        // Act
        var result = activity.GetPackage();

        // Assert
        Assert.That(result, Is.True);
    }
}