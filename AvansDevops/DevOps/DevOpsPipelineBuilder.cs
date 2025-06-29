using AvansDevops.DevOps.Analysis;
using AvansDevops.DevOps.Build;
using AvansDevops.DevOps.Deploy;
using AvansDevops.DevOps.Package;
using AvansDevops.DevOps.Source;
using AvansDevops.DevOps.Test;
using AvansDevops.DevOps.Utility;

namespace AvansDevops.DevOps;

public class DevOpsPipelineBuilder {
    private readonly DevOpsPipeline _pipeline = new();
    
    public DevOpsPipeline Build() {
        return _pipeline;
    }

    public DevOpsPipelineBuilder AddAnalysisActivity(AnalysisActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddAnalysisActivities(IEnumerable<AnalysisActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
    
    public DevOpsPipelineBuilder AddBuildActivity(BuildActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddBuildActivities(IEnumerable<BuildActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
    
    public DevOpsPipelineBuilder AddDeployActivity(DeployActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddDeployActivities(IEnumerable<DeployActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
    
    public DevOpsPipelineBuilder AddPackageActivity(PackageActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddPackageActivities(IEnumerable<PackageActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
    
    public DevOpsPipelineBuilder AddSourceActivity(SourceActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddSourceActivities(IEnumerable<SourceActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
    
    public DevOpsPipelineBuilder AddTestActivity(TestActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddTestActivities(IEnumerable<TestActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
    
    public DevOpsPipelineBuilder AddUtilityActivity(UtilityActivity activity) {
        _pipeline.Add(activity);
        return this;
    }
    
    public DevOpsPipelineBuilder AddUtilityActivities(IEnumerable<UtilityActivity> activities) {
        _pipeline.AddAll(activities);
        return this;
    }
}