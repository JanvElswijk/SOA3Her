namespace AvansDevops.DevOps.Deploy;

public class AzureActivity(string remoteUrl) : DeployActivity(remoteUrl) {
    
    //TODO: Add Azure-specific deployment options and configurations
    
    public override bool Deploy() {
        Console.WriteLine($"[DEVOPS : Deploy] Azure deployment started on remote: {remoteUrl}");
        return true;
    }
}