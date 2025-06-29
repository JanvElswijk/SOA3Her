namespace AvansDevops.DevOps;

public abstract class Activity {
    public abstract bool Execute(IPipelineVisitor visitor);
}