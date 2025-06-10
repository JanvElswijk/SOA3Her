public class Sprint
{
    private List<BacklogItem> _backlogItems;
    private List<User> _testers;
    private User _leadDeveloper;
    private User _scrumMaster;
    //private pipeline _pipeline;

//lijst van developers?
    public Sprint(List<BacklogItem> backlogItems, User leadDeveloper, List<User> testers, User scrumMaster)
    {
        _backlogItems = backlogItems;
        foreach (var backlogItem in _backlogItems)
        {
            backlogItem.SetSprint(this);
        }        

        _leadDeveloper = leadDeveloper;
        _testers = testers;
        _scrumMaster = scrumMaster;
    }




    public void NotifyTesters(BacklogItem item, string message)
    {
        _testers.ForEach(tester =>
        {
            tester.Update(item, message);
        });
    }

    public void NotifyScrumMaster(BacklogItem item, string message)
    {
        _scrumMaster.Update(item, message); 
    }
 
 

    public List<User> GetTesters()
    {
        return _testers;
    }
    
    public User getScrumMaster()
    {
        return _scrumMaster;
    }
    public User GetLeadDeveloper()
    {
        return _leadDeveloper;
    }
}