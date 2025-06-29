using AvansDevops.DevOps;
using AvansDevops.ProjectManagement;
using Moq;

namespace AvansDevops.Test.ProjectManagement.Sprint;

[TestFixture]
public class ReleaseStrategyTests
{

    [Test]
    public void Execute_WithValidPipelineAndSummary_ReturnsPipelineResult()
    {
        // Arrange
        var pipelineMock = new Mock<Pipeline>();
        pipelineMock.Setup(p => p.Execute(It.IsAny<IPipelineVisitor>())).Returns(true);
        var strategy = new ReleaseStrategy();

        // Act
        var result = strategy.Execute(pipelineMock.Object, "summary");

        // Assert
        Assert.That(result, Is.True);
    }
}