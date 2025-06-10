using AvansDevops.DevOps.Analysis;
using AvansDevops.DevOps.Build;
using AvansDevops.DevOps.Deploy;
using AvansDevops.DevOps.Package;
using AvansDevops.DevOps.Source;
using AvansDevops.DevOps.Test;
using AvansDevops.DevOps.Utility;

namespace AvansDevops.DevOps;

public class DevOpsPipelineVisitor : IPipelineVisitor {
    public void VisitPipeline(Pipeline pipeline) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting pipeline: {pipeline.GetType().Name}");
        Console.WriteLine(pipeline.Success ? "[DEVOPS : Visitor] Pipeline executed successfully." : "[DEVOPS : Visitor] Pipeline execution failed.");
    }

    public bool VisitAnalysisActivity(AnalysisActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting analysis activity: {activity.GetType().Name}");
        bool result = activity.Analyze();
        return result;
    }

    public bool VisitBuildActivity(BuildActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting build activity: {activity.GetType().Name}");
        bool result = activity.Build();
        return result;
    }

    public bool VisitDeployActivity(DeployActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting deploy activity: {activity.GetType().Name}");
        bool result = activity.Deploy();
        return result;
    }

    public bool VisitPackageActivity(PackageActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting package activity: {activity.GetType().Name}");
        bool result = activity.GetPackage();
        return result;    
    }

    public bool VisitSourceActivity(SourceActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting source activity: {activity.GetType().Name}");
        bool result = activity.GetSourceCode();
        return result;    
    }

    public bool VisitTestActivity(TestActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting test activity: {activity.GetType().Name}");
        bool result = activity.RunTests();
        return result;    
    }

    public bool VisitUtilityActivity(UtilityActivity activity) {
        Console.WriteLine($"[DEVOPS : Visitor] Visiting utility activity: {activity.GetType().Name}");
        bool result = activity.RunUtility();
        return result;    
    }
}