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


BacklogItem backlogItem = new BacklogItem("Implement Observer Pattern", "Implement the observer pattern in the project management system.", "In Progress", 5);

NotificationService notificationService = new NotificationService(new EmailAdapter());
notificationService.AddNotificationAdapter(new EmailAdapter()); //wont add
notificationService.AddNotificationAdapter(new SlackAdapter());

backlogItem.AddObserver(notificationService);
backlogItem.NotifyObservers("Testing Rejected, sent back to TODO");


SCMService _SCMService = new SCMService(new GitAdapter());
_SCMService.CreateBranch("feature/observer-pattern");
_SCMService.Commit("Implement observer pattern in project management system.");
_SCMService.Push();
_SCMService.Pull();

