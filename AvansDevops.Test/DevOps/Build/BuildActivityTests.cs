using AvansDevops.DevOps;
using AvansDevops.DevOps.Build;
using Moq;

namespace AvansDevops.Test.DevOps.Build;

public class BuildActivityTests {
    [Test]
    public void ExecuteShouldCallVisitBuildActivity() {
        // Arrange
        var packageActivity = new Mock<BuildActivity>();
        packageActivity.CallBase = true;
        packageActivity.Setup(a => a.Build()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitBuildActivity(packageActivity.Object)).Returns(true);

        // Act
        var result = packageActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitBuildActivity(packageActivity.Object), Times.Once);
    }
}