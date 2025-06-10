namespace AvansDevops.DevOps.Build;

public class DotNetActivity : BuildActivity {
    public override bool Build() {
        Console.WriteLine("[DEVOPS : Build] Building .NET project");
        return true;
    }
}