using AvansDevops.DevOps;
using Moq;

namespace AvansDevops.Test.DevOps;

public class DevOpsPipelineTests {
    private class TrueDummyActivity : Activity {
        public override bool Execute(IPipelineVisitor visitor) => true;
    }
    
    private class FalseDummyActivity : Activity {
        public override bool Execute(IPipelineVisitor visitor) => false;
    }
    
    
    [Test]
    public void DevOpsPipeline_Should_Execute_All_Build_Actions()
    {
        // Arrange
        var pipeline = new DevOpsPipeline();
        var visitorMock = new Mock<IPipelineVisitor>();
        var activity = new TrueDummyActivity();
        pipeline.Add(activity);

        // Act
        var result = pipeline.Execute(visitorMock.Object);

        // Assert
        visitorMock.Verify(v => v.VisitPipeline(pipeline), Times.Once);
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void DevOpsPipeline_Should_Return_False_When_Any_Action_Fails()
    {
        // Arrange
        var pipeline = new DevOpsPipeline();
        var visitorMock = new Mock<IPipelineVisitor>();
        var activity1 = new TrueDummyActivity();
        var activity2 = new FalseDummyActivity();
        pipeline.Add(activity1);
        pipeline.Add(activity2);

        // Act
        var result = pipeline.Execute(visitorMock.Object);

        // Assert
        visitorMock.Verify(v => v.VisitPipeline(pipeline), Times.Once);
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void DevOpsPipeline_Should_Return_True_When_All_Actions_Succeed()
    {
        // Arrange
        var pipeline = new DevOpsPipeline();
        var visitorMock = new Mock<IPipelineVisitor>();
        var activity1 = new TrueDummyActivity();
        var activity2 = new TrueDummyActivity();
        pipeline.Add(activity1);
        pipeline.Add(activity2);

        // Act
        var result = pipeline.Execute(visitorMock.Object);

        // Assert
        visitorMock.Verify(v => v.VisitPipeline(pipeline), Times.Once);
        Assert.That(result, Is.True);
    }
}