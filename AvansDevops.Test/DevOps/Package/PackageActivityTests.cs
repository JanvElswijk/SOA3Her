using AvansDevops.DevOps;
using AvansDevops.DevOps.Package;
using Moq;

namespace AvansDevops.Test.DevOps.Package;

public class PackageActivityTests {
    [Test]
    public void ExecuteShouldCallVisitPackageActivity() {
        // Arrange
        var packageActivity = new Mock<PackageActivity>("http://example.com/package");
        packageActivity.CallBase = true;
        packageActivity.Setup(a => a.GetPackage()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitPackageActivity(packageActivity.Object)).Returns(true);

        // Act
        var result = packageActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitPackageActivity(packageActivity.Object), Times.Once);
    }
}