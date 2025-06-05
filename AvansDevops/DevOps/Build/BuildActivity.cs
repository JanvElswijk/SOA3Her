namespace AvansDevops.DevOps.Build;

public abstract class BuildActivity : Activity {

    public abstract bool Build();
    
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitBuildActivity(this);
    }
}