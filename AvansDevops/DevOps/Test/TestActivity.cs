namespace AvansDevops.DevOps.Test;

public abstract class TestActivity(bool coverage, string? publishUrl) : Activity{
    private readonly bool _coverage = coverage;
    private readonly string? _publishUrl = publishUrl;
    
    public abstract bool RunTests();

    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitTestActivity(this);
    }
}