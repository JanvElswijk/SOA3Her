using AvansDevops.DevOps;
using AvansDevops.DevOps.Test;
using Moq;

namespace AvansDevops.Test.DevOps.Test;

public class TestActivityTests {
    [Test]
    public void ExecuteShouldCallVisitTestActivity() {
        // Arrange
        var testActivity = new Mock<TestActivity>(true, "http://example.com/publish");
        testActivity.CallBase = true;
        testActivity.Setup(a => a.RunTests()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitTestActivity(testActivity.Object)).Returns(true);

        // Act
        var result = testActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitTestActivity(testActivity.Object), Times.Once);
    }
}