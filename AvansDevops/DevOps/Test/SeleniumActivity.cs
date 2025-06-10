namespace AvansDevops.DevOps.Test;

public class SeleniumActivity(bool coverage, string? publishUrl) : TestActivity(coverage, publishUrl) {
    public override bool RunTests() {
        var sb = new System.Text.StringBuilder();
        sb.Append("[DEVOPS : Test] Running Selenium tests");
        if (coverage) {
            sb.Append(", with code coverage enabled");
        }
        if (!string.IsNullOrEmpty(publishUrl)) {
            sb.Append($", publishing results to {publishUrl}");
        }
        // sb.Append('\n');
        Console.WriteLine(sb.ToString());
        return true;
    }
}