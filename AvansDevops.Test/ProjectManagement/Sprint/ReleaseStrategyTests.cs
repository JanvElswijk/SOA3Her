using NUnit.Framework;
using AvansDevops.ProjectManagement;
using AvansDevops.DevOps;
using Moq;

[TestFixture]
public class ReleaseStrategyTests
{


    // [Test]
    // public void Execute_WithNullPipeline_ReturnsNull()
    // {
    //     using var sw = new StringWriter();
    //     Console.SetOut(sw);

    //     var strategy = new ReleaseStrategy();
    //     var pipelineMock = new Mock<DevOpsPipeline>();
    //     var result = strategy.Execute(pipelineMock.Object, "summary");

    //     Assert.That(result, Is.Null);

    //     // (optioneel) Console output terugzetten naar standaard
    //     Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    // }

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