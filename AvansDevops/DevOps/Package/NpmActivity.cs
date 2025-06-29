namespace AvansDevops.DevOps.Package;

public class NpmActivity(string packageUrl) : PackageActivity(packageUrl) {
    public override bool GetPackage() {
        Console.WriteLine($"[DEVOPS : Package] Getting package from npm repository: {packageUrl}");
        return true;
    }
}