namespace AvansDevops.DevOps.Build;

public class JenkinsActivity : BuildActivity {
    public override bool Build() {
        Console.WriteLine("[DEVOPS : Build] Building with Jenkins");
        return true;
    }
}