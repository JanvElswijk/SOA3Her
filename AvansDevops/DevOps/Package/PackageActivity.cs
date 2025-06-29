namespace AvansDevops.DevOps.Package;

public abstract class PackageActivity(string packageUrl) : Activity {
    private readonly string _packageUrl = packageUrl;
    public abstract bool GetPackage();
    public override bool Execute(IPipelineVisitor visitor) {
        return visitor.VisitPackageActivity(this);
    }
    
}