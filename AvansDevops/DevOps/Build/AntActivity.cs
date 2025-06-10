namespace AvansDevops.DevOps.Build;

public class AntActivity : BuildActivity{
    public override bool Build() {
        Console.WriteLine("[DEVOPS : Build] Building Ant project");
        return true;
    }
}