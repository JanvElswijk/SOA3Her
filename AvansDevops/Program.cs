using AvansDevops.DevOps;
using AvansDevops.DevOps.Analysis;
using AvansDevops.DevOps.Build;
using AvansDevops.DevOps.Deploy;
using AvansDevops.DevOps.Package;
using AvansDevops.DevOps.Source;
using AvansDevops.DevOps.Test;
using AvansDevops.DevOps.Utility;

AnalysisActivity aa = new SonarqubeActivity();
BuildActivity ba = new MavenActivity();
DeployActivity da = new AzureActivity("http://example.com/deploy");
PackageActivity pa = new NugetActivity("http://example.com/package");
SourceActivity sa = new GitHubActivity("https://example.com/repo.git");
TestActivity ta = new NUnitActivity(true, null);
UtilityActivity ua = new BatchScriptActivity("C:\\scripts\\deploy.bat");

DevOpsPipelineBuilder builder = new DevOpsPipelineBuilder();
DevOpsPipeline pipeline = builder
    .AddAnalysisActivity(aa)
    .AddBuildActivity(ba)
    .AddDeployActivity(da)
    .AddPackageActivity(pa)
    .AddSourceActivity(sa)
    .AddTestActivity(ta)
    .AddUtilityActivity(ua)
    .Build();

IPipelineVisitor visitor = new DevOpsPipelineVisitor();
pipeline.Execute(visitor);