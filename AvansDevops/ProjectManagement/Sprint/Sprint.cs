using AvansDevops.DevOps;

public class Sprint
{
    private List<BacklogItem> _backlogItems;
    private List<User> _testers;
    private User _leadDeveloper;
    private User _scrumMaster;
    private ISprintStrategy _strategy;
    private Pipeline _pipeline;
    private string _summary;
    //lijst van developers?
    public Sprint(List<BacklogItem> backlogItems, User leadDeveloper, List<User> testers, User scrumMaster, ISprintStrategy strategy, Pipeline pipeline)
    {
        _strategy = strategy;
        _backlogItems = backlogItems;
        foreach (var backlogItem in _backlogItems)
        {
            backlogItem.SetSprint(this);
        }

        _pipeline = pipeline;

        _leadDeveloper = leadDeveloper;
        _testers = testers;
        _scrumMaster = scrumMaster;
    }


    public void SetStrategy(ISprintStrategy strategy)
    {
        _strategy = strategy;
    }

    //FinishSprint();?  dit misschien callen vanuit state pattern?
    public void ExecuteStrategy()
    {
        _strategy.Execute(_pipeline, _summary);
    }

    public void SetSummary(string summary)
    {
        _summary = summary;
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