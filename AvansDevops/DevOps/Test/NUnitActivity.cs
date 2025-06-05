namespace AvansDevops.DevOps.Test;

public class NUnitActivity(bool coverage, string? publishUrl) : TestActivity(coverage, publishUrl) {
    public override bool RunTests() {
        Console.WriteLine("[DEVOPS : Test] Running NUnit tests");
        if (coverage) {
            Console.WriteLine("[DEVOPS : Test] Collecting code coverage");
        }
        if (!string.IsNullOrEmpty(publishUrl)) {
            Console.WriteLine($"[DEVOPS : Test] Publishing test results to {publishUrl}");
        }
        return true;
    }
}