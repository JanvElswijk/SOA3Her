using AvansDevops.DevOps;

public class Project
{
    private string _title;
    private Backlog _backlog;
    private SCMService _scmService;
    private List<User> _developers; //In project is het algemeen, in sprint specificeer je wie scrumMaster, leadDeveloper, testers zijn
    private User _productOwner;
    //private Forum forum;
    public Sprint _currentSprint{ get; private set; } //Current sprint, kan null zijn als er geen sprint is;

    public Project(string title, SCMService scmService, List<User> developers, User productOwner)
    {
        _title = title;
        _backlog = new Backlog();
        _scmService = scmService;
        _developers = developers;
        _productOwner = productOwner;
    }

    public void AddBacklogItem(BacklogItem item)
    {
        _backlog.AddBacklogItem(item);  //addBacklogItem in backlog
    }

    public void AddDeveloper(User developer)
    {
        _developers.Add(developer);
    }
    public void RemoveDeveloper(User developer)
    {
        _developers.Remove(developer);
    }

    public void StartNewSprint(User leadDeveloper, List<User> tester, User scrumMaster, ISprintStrategy strategy, Pipeline? pipeline)
    {
        _currentSprint = new Sprint(new Backlog(), leadDeveloper, tester, scrumMaster, _productOwner, strategy, pipeline);
    }
    public void FinishSprint()
    {
        _currentSprint.ExecuteStrategy();
        _currentSprint = null; // Reset current sprint after finishing
    }

    public void MoveBacklogItemToSprint(BacklogItem item)
    {

        if (_backlog._items.Contains(item) == false)
        {
            throw new InvalidOperationException("Backlog item does not exist in the backlog.");
        }


        if (_currentSprint == null)
        {
            throw new InvalidOperationException("No active sprint to move backlog item to.");
        }

        item.SetSprint(_currentSprint);

        _currentSprint._backlogItems.AddBacklogItem(item);
        _backlog._items.Remove(item);
    }

}