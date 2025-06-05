namespace AvansDevops.DevOps.Source;

public class GitHubActivity(string repositoryUrl) : SourceActivity(repositoryUrl) {
    public override bool GetSourceCode() {
        Console.WriteLine($"[DEVOPS : Source] Getting source code from GitHub repository: {repositoryUrl}");
        return true;
    }
}