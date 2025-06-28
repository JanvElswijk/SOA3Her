using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AvansDevops.ProjectManagement;
using AvansDevops.Notifications.Adapter;
using AvansDevops.ProjectManagement.Sprint;

public class BacklogItem
{
    // private List<INotificationObserver> _observers = new List<INotificationObserver>();
    public string Title;
    private string _description;
    public IBacklogItemState State;
    public int StoryPoints;
    private Sprint? _sprint;
    private List<BacklogItem> _activities = new List<BacklogItem>();

    public User? User;

    public BacklogItem(){}
    public BacklogItem(string title, string description, int storyPoints)
    {
        this.Title = title;
        this._description = description;
        this.State = new NotInSprintBacklogItemState();
        this.StoryPoints = storyPoints;
    }


    //Voeg een item toe aan de sprint en zet de state naar Todo
    public void SetSprint(Sprint sprint)
    {
        ChangeState(new TodoBacklogItemState(this));
        _sprint = sprint;
    }


    //Notify:
    //Als een item naar ready for testing gaat -> testers krijgen notificatie
    //Als een item van readyForTesting naar todo -> scrum master krijgt notificatie
    //als een item van tested naar readyfortesting gaat -> testers krijgen notificatie

    //verdere notificaties komen aan bod wanneer een sprint eindigt

    public void AddActivity(BacklogItem activity)
    {
        _activities.Add(activity);
    }

    public void ChangeState(IBacklogItemState newState)
    {
        this.State = newState;
    }
    
    public void Start()
    {
        State.Start();
    }
    public void Complete()
    {
        State.Complete();
    }
    public void Reject()
    {
        State.Reject();
    }
    public void Approve()
    {
        State.Approve();
    }
    
 

    public virtual Sprint? GetSprint()
    {
        return this._sprint;
    }

    public void SetUser(User user)
    {
        this.User = user;
    }

    public User? GetUser()
    {
        return this.User;
    }


}




//Backlog aanmaken
//Backlog vullen met backlog items

//Sprint aanmaken
//Sprint vullen met backlog items
//items die naar sprint gaan uit backlog halen

//developers, testers, lead developer (scrum master?) toevoegen
//