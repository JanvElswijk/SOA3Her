namespace AvansDevops.DevOps.Analysis;

public class SonarqubeActivity : AnalysisActivity {
    
    public override bool Analyze() {
        Console.WriteLine("[DEVOPS : Analysis] Preparing Sonarqube analysis");
        Console.WriteLine("[DEVOPS : Analysis] Running Sonarqube analysis");
        Console.WriteLine("[DEVOPS : Analysis] Generating Sonarqube report");
        return true;
    }
    
}