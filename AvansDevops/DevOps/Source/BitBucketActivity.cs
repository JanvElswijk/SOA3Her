namespace AvansDevops.DevOps.Source;

public class BitBucketActivity(string repositoryUrl) : SourceActivity(repositoryUrl) {
    public override bool GetSourceCode() {
        Console.WriteLine($"[DEVOPS : Source] Getting source code from BitBucket repository: {repositoryUrl}");
        return true;
    }
}