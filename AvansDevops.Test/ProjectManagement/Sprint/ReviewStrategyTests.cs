using AvansDevops.DevOps;
using AvansDevops.ProjectManagement;
using Moq;

namespace AvansDevops.Test.ProjectManagement.Sprint;

[TestFixture]
public class ReviewStrategyTests
{

    [SetUp]
    public void Setup()
    {
        Console.SetOut(new System.IO.StringWriter());
    }
    
    [Test]
    public void Execute_WithNullSummary_ReturnsNull()
    {
        // Arrange
        var pipelineMock = new Mock<Pipeline>();
        var strategy = new ReviewStrategy();

        // Act
        var result = strategy.Execute(pipelineMock.Object, null);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Execute_WithNullPipeline_ReturnsNull()
    {
        // Arrange
        var strategy = new ReviewStrategy();

        // Act
        var result = strategy.Execute(null, "summary");

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Execute_WithValidPipelineAndSummary_ReturnsPipelineResult()
    {
        // Arrange
        var pipelineMock = new Mock<Pipeline>();
        pipelineMock.Setup(p => p.Execute(It.IsAny<IPipelineVisitor>())).Returns(true);
        var strategy = new ReviewStrategy();

        // Act
        var result = strategy.Execute(pipelineMock.Object, "summary");

        // Assert
        Assert.That(result, Is.True);
    }
}