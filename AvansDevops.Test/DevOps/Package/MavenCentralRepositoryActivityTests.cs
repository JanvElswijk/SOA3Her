using AvansDevops.DevOps.Package;

namespace AvansDevops.Test.DevOps.Package;

[TestFixture]
public class MavenCentralRepositoryActivityTests
{
    [Test]
    public void GetPackageShouldReturnTrue()
    {
        // Arrange
        var activity = new MavenCentralRepositoryActivity("mvnrepository.com/test");

        // Act
        var result = activity.GetPackage();

        // Assert
        Assert.That(result, Is.True);
    }
}