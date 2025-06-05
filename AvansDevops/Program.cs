

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

