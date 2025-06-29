namespace AvansDevops.DevOps.Deploy;

public class AWSActivity(string remoteUrl) : DeployActivity(remoteUrl) {
    public override bool Deploy()
    {
        Console.WriteLine($"[DEVOPS : Deploy] Azure deployment started on remote: {remoteUrl}");
        return true;
    }
    
}