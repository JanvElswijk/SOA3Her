namespace AvansDevops.DevOps.Build;

public class DotNetCoreActivity : BuildActivity{
    public override bool Build() {
        Console.WriteLine("[DEVOPS : Build] Building .NET Core project");
        return true;
    }
}