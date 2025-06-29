using AvansDevops.DevOps;
using AvansDevops.DevOps.Deploy;
using Moq;

namespace AvansDevops.Test.DevOps.Deploy;

public class DeployActivityTests {
    [Test]
    public void ExecuteShouldCallVisitDeployActivity() {
        // Arrange
        var packageActivity = new Mock<DeployActivity>("http://example.com/package");
        packageActivity.CallBase = true;
        packageActivity.Setup(a => a.Deploy()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitDeployActivity(packageActivity.Object)).Returns(true);

        // Act
        var result = packageActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitDeployActivity(packageActivity.Object), Times.Once);
    }
}