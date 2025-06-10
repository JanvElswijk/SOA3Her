using AvansDevops.DevOps.Analysis;
using AvansDevops.DevOps.Build;
using AvansDevops.DevOps.Deploy;
using AvansDevops.DevOps.Package;
using AvansDevops.DevOps.Source;
using AvansDevops.DevOps.Test;
using AvansDevops.DevOps.Utility;

namespace AvansDevops.DevOps;

public interface IPipelineVisitor {
    public void VisitPipeline(Pipeline pipeline);
    public bool VisitAnalysisActivity(AnalysisActivity activity);
    public bool VisitBuildActivity(BuildActivity activity);
    public bool VisitDeployActivity(DeployActivity activity);
    public bool VisitPackageActivity(PackageActivity activity);
    public bool VisitSourceActivity(SourceActivity activity);
    public bool VisitTestActivity(TestActivity activity);
    public bool VisitUtilityActivity(UtilityActivity activity);
    
    
}