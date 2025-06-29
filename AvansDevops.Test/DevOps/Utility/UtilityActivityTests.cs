using AvansDevops.DevOps;
using AvansDevops.DevOps.Utility;
using Moq;

namespace AvansDevops.Test.DevOps.Utility;

public class UtilityActivityTests {
    [Test]
    public void ExecuteShouldCallVisitUtilityActivity() {
        // Arrange
        var utilityActivity = new Mock<UtilityActivity>();
        utilityActivity.CallBase = true;
        utilityActivity.Setup(a => a.RunUtility()).Returns(true);
        var visitor = new Mock<IPipelineVisitor>();
        visitor.Setup(v => v.VisitUtilityActivity(utilityActivity.Object)).Returns(true);

        // Act
        var result = utilityActivity.Object.Execute(visitor.Object);

        // Assert
        Assert.That(result, Is.True);
        visitor.Verify(v => v.VisitUtilityActivity(utilityActivity.Object), Times.Once);
    }
}