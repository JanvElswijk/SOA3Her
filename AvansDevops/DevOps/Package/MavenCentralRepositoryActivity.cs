namespace AvansDevops.DevOps.Package;

public class MavenCentralRepositoryActivity(string packageUrl) : PackageActivity(packageUrl) {
    public override bool GetPackage() {
        Console.WriteLine($"[DEVOPS : Package] Getting package from Maven Central Repository: {packageUrl}");
        return true;
    }
}