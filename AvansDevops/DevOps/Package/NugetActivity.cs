namespace AvansDevops.DevOps.Package;

public class NugetActivity(string packageUrl) : PackageActivity(packageUrl) {
    public override bool GetPackage() {
        Console.WriteLine($"[DEVOPS : Package] Getting NuGet package from: {packageUrl}");
        return true;
    }
}