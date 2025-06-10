namespace AvansDevops.DevOps;

public abstract class Pipeline : ActivityComposite {
    public bool Success { get; private set; }
    
    public override bool Execute(IPipelineVisitor visitor) {
        Success = base.Execute(visitor);
        visitor.VisitPipeline(this);
        return Success;
    }
    
    public List<Activity> GetActivities() {
        return Activities;
    }
}