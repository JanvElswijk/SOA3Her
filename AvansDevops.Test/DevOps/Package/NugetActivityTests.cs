using AvansDevops.DevOps.Package;

namespace AvansDevops.Test.DevOps.Package;

[TestFixture]
public class NugetActivityTests
{
    [Test]
    public void GetPackageShouldReturnTrue()
    {
        // Arrange
        var activity = new NugetActivity("nuget.com/test");

        // Act
        var result = activity.GetPackage();

        // Assert
        Assert.That(result, Is.True);
    }
}