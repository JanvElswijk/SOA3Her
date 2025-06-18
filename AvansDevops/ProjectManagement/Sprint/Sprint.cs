using AvansDevops.DevOps;

public class Sprint
{
    public Backlog _backlogItems { get; private set; }
    private List<User> _testers;
    private User _leadDeveloper;
    private User _scrumMaster;
    private ISprintStrategy _strategy;
    private User _productOwner; //misschien weg
    private Pipeline _pipeline;
    private string _summary;

    private List<INotificationObserver> _observers = new List<INotificationObserver>();

    public Sprint(Backlog backlogItems, User leadDeveloper, List<User> testers, User scrumMaster, User productowner, ISprintStrategy strategy, Pipeline? pipeline)
    {
        _productOwner = productowner;
        _strategy = strategy;
        _backlogItems = backlogItems;
        foreach (var backlogItem in _backlogItems._items)
        {
            backlogItem.SetSprint(this);
        }

        _pipeline = pipeline;

        _leadDeveloper = leadDeveloper;
        _testers = testers;

        _scrumMaster = scrumMaster;


        //add observers
        _observers.Add(_scrumMaster);
        _observers.Add(_productOwner);
        _observers.AddRange(_testers);
    }

    public void AddObserver(INotificationObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            
        _observers.Add(observer);
        }
    }
    public void RemoveObserver(INotificationObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }


    public void SetStrategy(ISprintStrategy strategy)
    {
        _strategy = strategy;
    }

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

    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
            observer.Update(null, message);
    }

    public void NotifyTesters(BacklogItem item, string message)
    {
     foreach (var observer in _observers.OfType<User>().Where(u => u.GetRole() == UserRole.Tester))
    {
        observer.Update(item, message);
    }
    }

public void NotifyScrumMaster(BacklogItem item, string message)
{
    foreach (var observer in _observers.OfType<User>().Where(u => u.GetRole() == UserRole.ScrumMaster))
    {
        observer.Update(item, message);
    }
}

public void NotifyProductOwner(string message)
{
    foreach (var observer in _observers.OfType<User>().Where(u => u.GetRole() == UserRole.ProductOwner))
    {
        observer.Update(null, message);
    }
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