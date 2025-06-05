public class Sprint
{
    private List<BacklogItem> _backlogItems;
    private List<User> _testers = new List<User>();
    private User _leadDeveloper;
    private User _scrumMaster;
    //private pipeline _pipeline;

    public Sprint(List<BacklogItem> backlogItems, User leadDeveloper, List<User> testers)
    {
        _backlogItems = backlogItems;
        _leadDeveloper = leadDeveloper;
        _testers = testers;
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