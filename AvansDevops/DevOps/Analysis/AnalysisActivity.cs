namespace AvansDevops.DevOps.Analysis;

public abstract class AnalysisActivity : Activity {
    //TODO: Look at "analysis preparation, analysis execution, analysis reporting"
    public abstract bool Analyze();
    
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitAnalysisActivity(this);
    }
}