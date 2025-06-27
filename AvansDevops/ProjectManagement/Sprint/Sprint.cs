
using AvansDevops.DevOps;
using AvansDevops.Notifications.Adapter;
using AvansDevops.ProjectManagement;


namespace AvansDevops.ProjectManagement;
public class Sprint 
{
    public Backlog _backlogItems { get; private set; }
    private List<User> _testers;
    private User _leadDeveloper;
    private User _scrumMaster;
    private ISprintStrategy _strategy;
    private Pipeline _pipeline;
    private string _summary;
    private Project _project;

    private List<INotificationObserver> _observers = new List<INotificationObserver>();

    public Sprint()
    {
        
    }

    public Sprint(Project project, Backlog backlogItems, User leadDeveloper, List<User> testers, User scrumMaster, ISprintStrategy strategy, Pipeline? pipeline)
    {
        _project = project;
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
        _observers.Add(_project._productOwner);
        _observers.AddRange(_testers);
    }


    //cc2
    public void AddObserver(INotificationObserver observer)
    {
        if (!_observers.Contains(observer))
        {

            _observers.Add(observer);
        }
    }
    
    
    //cc2
    public void RemoveObserver(INotificationObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
        }
    }


    public IReadOnlyList<INotificationObserver> GetObservers()
    {
        return _observers.AsReadOnly();
    }



    //cc1
    public void SetStrategy(ISprintStrategy strategy)
    {
        _strategy = strategy;
    }

    //cc3
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


    //cc1
    public void SetSummary(string summary)
    {
        _summary = summary;
    }

    //cc1
    public void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
            observer.Update(null, message);
    }


    //cc1
    public void NotifyTesters(BacklogItem? item , string message)
    {
        foreach (var observer in _observers.OfType<User>().Where(u => u.GetRole() == UserRole.Tester))
        {
            observer.Update(item, message);
        }
    }


    //cc1
    public void NotifyScrumMaster(BacklogItem item, string message)
    {
        foreach (var observer in _observers.OfType<User>().Where(u => u.GetRole() == UserRole.ScrumMaster))
        {
            observer.Update(item, message);
        }
    }

    //cc1
    public void NotifyProductOwner(string message)
    {
        foreach (var observer in _observers.OfType<User>().Where(u => u.GetRole() == UserRole.ProductOwner))
        {
            observer.Update(null, message);
        }
    }

 
}