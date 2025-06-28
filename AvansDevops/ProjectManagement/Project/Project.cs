using AvansDevops.DevOps;
using AvansDevops.ProjectManagement.Forum;

namespace AvansDevops.ProjectManagement.Project;
public class Project
{
    public string Title;
    public Backlog _backlog;
    private SCMService _scmService;
    public List<User> Developers; //In project is het algemeen, in sprint specificeer je wie scrumMaster, leadDeveloper, testers zijn
    public User _productOwner;
    public Forum.Forum _forum;
    public Sprint.Sprint _currentSprint { get; private set; } //Current sprint, kan null zijn als er geen sprint is;

    public Project(string title, SCMService scmService, List<User> developers, User productOwner)
    {
        _forum = new Forum.Forum();
        Title = title;
        _backlog = new Backlog();
        _scmService = scmService;
        Developers = developers;
        _productOwner = productOwner;
    }

    public void AddThread(BacklogItem backlogItem)
    {
        _forum.CreateThread(backlogItem); 
    }

    public void AddBacklogItem(BacklogItem item)
    {
        _backlog.AddBacklogItem(item);  //addBacklogItem in backlog
    }

    public void AddDeveloper(User developer)
    {
        Developers.Add(developer);
    }
    public void RemoveDeveloper(User developer)
    {
        Developers.Remove(developer);
    }

    public void StartNewSprint(User leadDeveloper, List<User> tester, User scrumMaster, ISprintStrategy strategy, Pipeline? pipeline)
    {
        _currentSprint = new Sprint.Sprint(this, new Backlog(), leadDeveloper, tester, scrumMaster, strategy, pipeline);
    }
    public void FinishSprint()
    {
        _currentSprint.ExecuteStrategy();
        _currentSprint = null; 
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