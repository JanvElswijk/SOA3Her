using AvansDevops.DevOps;
using AvansDevops.DevOps.Analysis;
using AvansDevops.DevOps.Build;
using AvansDevops.DevOps.Deploy;
using AvansDevops.DevOps.Package;
using AvansDevops.DevOps.Source;
using AvansDevops.DevOps.Test;
using AvansDevops.DevOps.Utility;

AnalysisActivity aa = new SonarqubeActivity();

BuildActivity ba = new AntActivity();
BuildActivity ba2 = new DotNetActivity();
BuildActivity ba3 = new DotNetCoreActivity();
BuildActivity ba4 = new JenkinsActivity();
BuildActivity ba5 = new MavenActivity();

DeployActivity da = new AWSActivity("http://aws.com/deploy");
DeployActivity da2 = new AzureActivity("http://azure.com/deploy");

PackageActivity pa = new MavenCentralRepositoryActivity("https://repo.maven.apache.org/package");
PackageActivity pa2 = new NpmActivity("https://registry.npmjs.org/package");
PackageActivity pa3 = new NugetActivity("https://api.nuget.org/package");

SourceActivity sa = new BitBucketActivity("https://bitbucket.org/repo.git");
SourceActivity sa2 = new GitHubActivity("https://github.com/repo.git");
SourceActivity sa3 = new GitLabActivity("https://gitlab.com/repo.git");

TestActivity ta = new JUnitActivity(true, "https://example.org/junit/report");
TestActivity ta2 = new NUnitActivity(true, "https://example.org/nunit/report");
TestActivity ta3 = new SeleniumActivity(true, "https://example.org/selenium/report");

UtilityActivity ua = new BatchScriptActivity("C:\\scripts\\clearcache.bat");
UtilityActivity ua2 = new FileActivity("C:\\images\\icon.png", "C:\\images\\icon_backup.png");
UtilityActivity ua3 = new FileActivity("C:\\images\\temp.png");
UtilityActivity ua4 = new FileActivity(new Uri("https://example.org/icon.png"));

DevOpsPipelineBuilder builder = new DevOpsPipelineBuilder();
DevOpsPipeline pipeline = builder
    .AddAnalysisActivity(aa)
    .AddBuildActivity(ba)
    .AddBuildActivity(ba2)
    .AddBuildActivity(ba3)
    .AddBuildActivity(ba4)
    .AddBuildActivity(ba5)
    .AddDeployActivity(da)
    .AddDeployActivity(da2)
    .AddPackageActivity(pa)
    .AddPackageActivity(pa2)
    .AddPackageActivity(pa3)
    .AddSourceActivity(sa)
    .AddSourceActivity(sa2)
    .AddSourceActivity(sa3)
    .AddTestActivity(ta)
    .AddTestActivity(ta2)
    .AddTestActivity(ta3)
    .AddUtilityActivity(ua)
    .AddUtilityActivity(ua2)
    .AddUtilityActivity(ua3)
    .AddUtilityActivity(ua4)
    .Build();

// IPipelineVisitor visitor = new DevOpsPipelineVisitor();
// pipeline.Execute(visitor);


BacklogItem backlogItem = new BacklogItem("Implement Observer Pattern", "Implement the observer pattern in the project management system.", 5);

NotificationService notificationService = new NotificationService(new EmailAdapter());
notificationService.AddNotificationAdapter(new EmailAdapter()); //wont add
notificationService.AddNotificationAdapter(new SlackAdapter());


User developer = new User("Alice", "alice@mail.com", UserRole.Developer);
User leadDeveloper = new User("Bob", "bob@mail.com", UserRole.LeadDeveloper);
User scrumMaster = new User("Charlie", "charlie@mail.com", UserRole.ScrumMaster);
User tester = new User("Dave", "dave@mail.com", UserRole.Tester);


Sprint sprint = new Sprint(new List<BacklogItem> { backlogItem }, leadDeveloper, new List<User> { tester }, scrumMaster, new ReviewStrategy(), pipeline);


SCMService _SCMService = new SCMService(new GitAdapter());
_SCMService.CreateBranch("feature/observer-pattern");
_SCMService.Commit("Implement observer pattern in project management system.");
_SCMService.Push();
_SCMService.Pull();

backlogItem.SetUser(developer);
backlogItem.Start(); //todo -> doing
backlogItem.Complete(); //todo -> ready for testing //notify dave


sprint.ExecuteStrategy();
sprint.SetSummary("Okay");
sprint.ExecuteStrategy();
