namespace AvansDevops.DevOps.Utility;

public class BatchScriptActivity(string path) : UtilityActivity {
    public override bool RunUtility() {
        Console.WriteLine($"[DEVOPS : Utility] Running batch script at: {path}");
        return true;
    }
}