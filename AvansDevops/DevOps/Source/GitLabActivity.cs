namespace AvansDevops.DevOps.Source;

public class GitLabActivity(string repositoryUrl) : SourceActivity(repositoryUrl) {
    public override bool GetSourceCode() {
        Console.WriteLine($"[DEVOPS : Source] Getting source code from GitLab repository: {repositoryUrl}");
        return true;
    }
}