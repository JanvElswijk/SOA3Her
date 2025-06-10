namespace AvansDevops.DevOps.Utility;

public class CliActivity(string command) : UtilityActivity
{
    public override bool RunUtility() {
        Console.WriteLine($"[DEVOPS : Utility] Running CLI command: {command}");
        return true;
    }
}