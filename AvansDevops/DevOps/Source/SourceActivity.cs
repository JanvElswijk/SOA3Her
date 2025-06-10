namespace AvansDevops.DevOps.Source;

public abstract class SourceActivity(string repositoryUrl) : Activity {
    private readonly string _repositoryUrl = repositoryUrl;
    public abstract bool GetSourceCode();
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitSourceActivity(this);
    }
}