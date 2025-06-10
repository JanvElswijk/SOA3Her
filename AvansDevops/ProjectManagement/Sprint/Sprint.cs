using AvansDevops.DevOps;

public class Sprint
{
    private List<BacklogItem> _backlogItems;
    private List<User> _testers;
    private User _leadDeveloper;
    private User _scrumMaster;
    private ISprintStrategy _strategy;
    private Pipeline _pipeline;
    private User _productOwner;
    private string _summary;
    //lijst van developers?
    public Sprint(List<BacklogItem> backlogItems, User leadDeveloper, List<User> testers, User scrumMaster, User productowner, ISprintStrategy strategy, Pipeline pipeline)
    {
        _productOwner = productowner;
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
        bool? result = _strategy.Execute(_pipeline, _summary);

        if (result == true)
        {
            NotifyScrumMaster(null, "Sprint completed successfully.");
            NotifyProductOwner("Sprint completed successfully.");
        }
        else if (result == false)
        {
            NotifyScrumMaster(null, "Sprint failed.");
        }
    
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

    public void NotifyScrumMaster(BacklogItem? item,string message)
    {
        _scrumMaster.Update(item, message); 
    }


    public void NotifyProductOwner(string message)
    {
        _productOwner.Update(null, message);
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