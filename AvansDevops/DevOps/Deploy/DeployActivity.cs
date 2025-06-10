namespace AvansDevops.DevOps.Deploy;

public abstract class DeployActivity(string remoteUrl) : Activity {
    private readonly string _remoteUrl = remoteUrl;
    public abstract bool Deploy();
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitDeployActivity(this);
    }
}