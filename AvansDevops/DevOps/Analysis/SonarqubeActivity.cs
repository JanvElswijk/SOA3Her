namespace AvansDevops.DevOps.Analysis;

public class SonarqubeActivity : AnalysisActivity {
    
    //TODO: Add Sonarqube specific properties if needed
    
    public override bool Analyze() {
        Console.WriteLine("[DEVOPS : Analysis] Sonarqube analysis started");
        return true;
    }
    
}