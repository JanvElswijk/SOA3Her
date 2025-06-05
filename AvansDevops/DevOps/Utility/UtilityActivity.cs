namespace AvansDevops.DevOps.Utility;

public abstract class UtilityActivity : Activity {
    public abstract bool RunUtility();
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitUtilityActivity(this);
    }
}