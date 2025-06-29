namespace AvansDevops.DevOps.Analysis;

public abstract class AnalysisActivity : Activity {
    public abstract bool Analyze();
    
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitAnalysisActivity(this);
    }
}