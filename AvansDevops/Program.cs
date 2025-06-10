

BacklogItem backlogItem = new BacklogItem("Implement Observer Pattern", "Implement the observer pattern in the project management system.", 5);

NotificationService notificationService = new NotificationService(new EmailAdapter());
notificationService.AddNotificationAdapter(new EmailAdapter()); //wont add
notificationService.AddNotificationAdapter(new SlackAdapter());


User developer = new User("Alice", "alice@mail.com", UserRole.Developer);
User leadDeveloper = new User("Bob", "bob@mail.com", UserRole.LeadDeveloper);
User scrumMaster = new User("Charlie", "charlie@mail.com", UserRole.ScrumMaster);
User tester = new User("Dave", "dave@mail.com", UserRole.Tester);


Sprint sprint = new Sprint(new List<BacklogItem> { backlogItem }, leadDeveloper, new List<User> { tester }, scrumMaster);


SCMService _SCMService = new SCMService(new GitAdapter());
_SCMService.CreateBranch("feature/observer-pattern");
_SCMService.Commit("Implement observer pattern in project management system.");
_SCMService.Push();
_SCMService.Pull();

backlogItem.SetUser(developer);
backlogItem.Start(); //todo -> doing
backlogItem.Complete(); //todo -> ready for testing



