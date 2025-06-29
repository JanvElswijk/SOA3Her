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

public class DevOpsPipelineBuilderTests {
    [Test]
    public void BuildPipeline_ShouldReturnPipeline_WhenActionsAreAdded() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        builder.AddBuildActivity(new MavenActivity());
        builder.AddBuildActivities(new List<BuildActivity>() {
            new DotNetActivity(),
            new JenkinsActivity(),
            new AntActivity()
        });

        // Act
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline, Is.Not.Null);
        Assert.That(pipeline.GetActivities().Count, Is.EqualTo(4));
    }
    
    [Test]
    public void AddAnalysisActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<AnalysisActivity>();
        var activity2 = new Mock<AnalysisActivity>();
        var activity3 = new Mock<AnalysisActivity>();
        
        // Act
        builder.AddAnalysisActivity(activity.Object);
        builder.AddAnalysisActivities(new List<AnalysisActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
    [Test]
    public void AddBuildActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<BuildActivity>();
        var activity2 = new Mock<BuildActivity>();
        var activity3 = new Mock<BuildActivity>();
        
        // Act
        builder.AddBuildActivity(activity.Object);
        builder.AddBuildActivities(new List<BuildActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
    [Test]
    public void AddDeployActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<DeployActivity>("deploy.com");  
        var activity2 = new Mock<DeployActivity>("deploy.com");
        var activity3 = new Mock<DeployActivity>("deploy.com");
        
        // Act
        builder.AddDeployActivity(activity.Object);
        builder.AddDeployActivities(new List<DeployActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
    [Test]
    public void AddPackageActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<PackageActivity>("package.com");
        var activity2 = new Mock<PackageActivity>("package.com");
        var activity3 = new Mock<PackageActivity>("package.com");
        
        // Act
        builder.AddPackageActivity(activity.Object);
        builder.AddPackageActivities(new List<PackageActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
    [Test]
    public void AddSourceActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<SourceActivity>("source.com");
        var activity2 = new Mock<SourceActivity>("source.com");
        var activity3 = new Mock<SourceActivity>("source.com");
        
        // Act
        builder.AddSourceActivity(activity.Object);
        builder.AddSourceActivities(new List<SourceActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
    [Test]
    public void AddTestActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<TestActivity>(true, "publish.com");
        var activity2 = new Mock<TestActivity>(true, "publish.com");
        var activity3 = new Mock<TestActivity>(true, "publish.com");
        
        // Act
        builder.AddTestActivity(activity.Object);
        builder.AddTestActivities(new List<TestActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
    [Test]
    public void AddUtilityActivity_ShouldAddActivity_WhenCalled() {
        // Arrange
        var builder = new DevOpsPipelineBuilder();
        var activity = new Mock<UtilityActivity>();
        var activity2 = new Mock<UtilityActivity>();
        var activity3 = new Mock<UtilityActivity>();
        
        // Act
        builder.AddUtilityActivity(activity.Object);
        builder.AddUtilityActivities(new List<UtilityActivity> { activity2.Object, activity3.Object });
        var pipeline = builder.Build();

        // Assert
        Assert.That(pipeline.GetActivities().Contains(activity.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity2.Object), Is.True);
        Assert.That(pipeline.GetActivities().Contains(activity3.Object), Is.True);
    }
    
}