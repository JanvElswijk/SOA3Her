using AvansDevops.DevOps;
using AvansDevops.DevOps.Analysis;
using Moq;

namespace AvansDevops.Test.DevOps.Analysis;

public class AnalysisActivityTests {
    [Test]
    public void ExecuteShouldCallVisitAnalysisActivity() {
        // Arrange
        var packageActivity = new Mock<AnalysisActivity>();
        packageActivity.CallBase = true;
        packageActivity.Setup(a => a.Analyze()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitAnalysisActivity(packageActivity.Object)).Returns(true);

        // Act
        var result = packageActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitAnalysisActivity(packageActivity.Object), Times.Once);
    }
}