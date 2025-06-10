namespace AvansDevops.DevOps.Build;

public class MavenActivity : BuildActivity {
    
    // TODO: Add some Maven-specific build options and configurations
    
    public override bool Build() {
        Console.WriteLine("[DEVOPS : Build] Maven build started");
        return true;
    }
}