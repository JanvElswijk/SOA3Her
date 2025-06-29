using AvansDevops.DevOps;
using AvansDevops.DevOps.Analysis;
using AvansDevops.DevOps.Build;
using AvansDevops.DevOps.Deploy;
using AvansDevops.DevOps.Package;
using AvansDevops.DevOps.Source;
using AvansDevops.DevOps.Test;
using AvansDevops.DevOps.Utility;
using Moq;

namespace AvansDevops.Test.DevOps;

[TestFixture]
public class DevOpsPipelineVisitorTests {
    
    [SetUp]
    public void Setup() {
        
    }
    
    [Test]
    public void VisitPipeline_ShouldReturnTrue_WhenPipelineIsExecuted() {
        // Arrange
        var pipeline = new Mock<Pipeline>();
        pipeline.Setup(p => p.Execute(It.IsAny<DevOpsPipelineVisitor>())).Returns(true);
        var visitor = new DevOpsPipelineVisitor();

        // Act
        var result = pipeline.Object.Execute(visitor);
        
        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void VisitPipeline_ShouldReturnFalse_WhenPipelineExecutionFails() {
        // Arrange
        var pipeline = new Mock<Pipeline>();
        pipeline.Setup(p => p.Execute(It.IsAny<DevOpsPipelineVisitor>())).Returns(false);
        var visitor = new DevOpsPipelineVisitor();

        // Act
        var result = pipeline.Object.Execute(visitor);
        
        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void VisitAnalysisActivity_ShouldCallAnalyze_WhenVisitingAnalyzeActivity() {
        // Arrange
        var analyzeActivity = new Mock<AnalysisActivity>();
        analyzeActivity.Setup(a => a.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitAnalysisActivity(analyzeActivity.Object);
        
        // Assert
        analyzeActivity.Verify(a => a.Analyze(), Times.Once);
    }
    
    [Test]
    public void VisitBuildActivity_ShouldCallBuild_WhenVisitingBuildActivity() {
        // Arrange
        var buildActivity = new Mock<BuildActivity>();
        buildActivity.Setup(b => b.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitBuildActivity(buildActivity.Object);
        
        // Assert
        buildActivity.Verify(b => b.Build(), Times.Once);
    }
    
        
    [Test]
    public void VisitDeployActivity_ShouldCallDeploy_WhenVisitingDeployActivity() {
        // Arrange
        var deployActivity = new Mock<DeployActivity>("deploy.com");
        deployActivity.Setup(d => d.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitDeployActivity(deployActivity.Object);
        
        // Assert
        deployActivity.Verify(d => d.Deploy(), Times.Once);
    }
    
        
    [Test]
    public void VisitPackageActivity_ShouldCallGetPackage_WhenVisitingDeployActivity() {
        // Arrange
        var packageActivity = new Mock<PackageActivity>("package.com");
        packageActivity.Setup(p => p.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitPackageActivity(packageActivity.Object);
        
        // Assert
        packageActivity.Verify(p => p.GetPackage(), Times.Once);
    }
    
    [Test]
    public void VisitSourceActivity_ShouldCallGetSourceCode_WhenVisitingSourceActivity() {
        // Arrange
        var sourceActivity = new Mock<SourceActivity>("source.com");
        sourceActivity.Setup(s => s.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitSourceActivity(sourceActivity.Object);
        
        // Assert
        sourceActivity.Verify(s => s.GetSourceCode(), Times.Once);
    }
    
    [Test]
    public void VisitTestActivity_ShouldCallTest_WhenVisitingTestActivity() {
        // Arrange
        var testActivity = new Mock<TestActivity>(true, "publish.com");
        testActivity.Setup(t => t.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitTestActivity(testActivity.Object);
        
        // Assert
        testActivity.Verify(t => t.RunTests(), Times.Once);
    }
    
    [Test]
    public void VisitUtlityActivity_ShouldCallRunUtility_WhenVisitingUtilityActivity() {
        // Arrange
        var utilityActivity = new Mock<UtilityActivity>();
        utilityActivity.Setup(u => u.Execute(It.IsAny<IPipelineVisitor>())).Verifiable();
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitUtilityActivity(utilityActivity.Object);
        
        // Assert
        utilityActivity.Verify(u => u.RunUtility(), Times.Once);
    }
    
    [Test]
    public void VisitPipeline_ShouldHandleMultipleActivities() {
        // Arrange
        var analyzeActivity = new Mock<AnalysisActivity>();
        var buildActivity = new Mock<BuildActivity>();
        var testActivity = new Mock<TestActivity>(true, "publish.com");
        var deployActivity = new Mock<DeployActivity>("deploy.com");
        var packageActivity = new Mock<PackageActivity>("package.com");
        var sourceActivity = new Mock<SourceActivity>("source.com");
        var utilityActivity = new Mock<UtilityActivity>();
        
        
        var visitor = new DevOpsPipelineVisitor();
        
        // Act
        visitor.VisitAnalysisActivity(analyzeActivity.Object);
        visitor.VisitBuildActivity(buildActivity.Object);
        visitor.VisitTestActivity(testActivity.Object);
        visitor.VisitDeployActivity(deployActivity.Object);
        visitor.VisitPackageActivity(packageActivity.Object);
        visitor.VisitSourceActivity(sourceActivity.Object);
        visitor.VisitUtilityActivity(utilityActivity.Object);
        
        // Assert
        analyzeActivity.Verify(a => a.Analyze(), Times.Once);
        buildActivity.Verify(b => b.Build(), Times.Once);
        testActivity.Verify(t => t.RunTests(), Times.Once);
        deployActivity.Verify(d => d.Deploy(), Times.Once);
        packageActivity.Verify(p => p.GetPackage(), Times.Once);
        sourceActivity.Verify(s => s.GetSourceCode(), Times.Once);
        utilityActivity.Verify(u => u.RunUtility(), Times.Once);
    }
}