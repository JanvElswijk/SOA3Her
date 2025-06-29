using AvansDevops.DevOps;
using AvansDevops.DevOps.Source;
using Moq;

namespace AvansDevops.Test.DevOps.Source;

public class TestActivityTests {
    [Test]
    public void ExecuteShouldCallVisitSourceActivity() {
        // Arrange
        var sourceActivity = new Mock<SourceActivity>("http://example.com/source");
        sourceActivity.CallBase = true;
        sourceActivity.Setup(a => a.GetSourceCode()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitSourceActivity(sourceActivity.Object)).Returns(true);

        // Act
        var result = sourceActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitSourceActivity(sourceActivity.Object), Times.Once);
    }
}