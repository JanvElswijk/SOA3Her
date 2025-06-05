using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class BacklogItem
{
    // private List<INotificationObserver> _observers = new List<INotificationObserver>();
    private string _title;
    private string _description;
    private IBacklogItemState _state;
    private int _storyPoints;
    private Sprint? _sprint;
    private List<BacklogItem> _activities = new List<BacklogItem>();

    private User? _user;

    public BacklogItem(string title, string description, IBacklogItemState state, int storyPoints)
    {
        this._title = title;
        this._description = description;
        this._state = state;
        this._storyPoints = storyPoints;
    }



    //Notify:
    //Als een item naar ready for testing gaat -> testers krijgen notificatie
    //Als een item van readyForTesting naar todo -> scrum master krijgt notificatie
    //als een item van tested naar readyfortesting gaat -> testers krijgen notificatie

    //verdere notificaties komen aan bod wanneer een sprint eindigt

    public void NotifyTesters(string message)
    {
        _sprint.GetTesters().ForEach(tester =>
           {
               tester.Update(this, message);
           });
    }


    public void NotifyScrumMaster(string message)
    {
        _sprint.getScrumMaster().Update(this, message);
    }



    public void ChangeState(IBacklogItemState newState)
    {
        this._state = newState;
    }


//wordt dit gebruikt?
    public void SetUser(User user)
    {
        this._user = user;
    }
        
    public User? GetUser()
    {
        return this._user;
    }
    // public void AddObserver(INotificationObserver observer)
    // {
    //     _observers.Add(observer);
    // }


    // public void NotifyObservers(string message)
    // {
    //     foreach (var observer in _observers)
    //     {
    //         observer.Update(this, message);
    //     }
    // }
}




//Backlog aanmaken
//Backlog vullen met backlog items

//Sprint aanmaken
//Sprint vullen met backlog items
//items die naar sprint gaan uit backlog halen

//developers, testers, lead developer (scrum master?) toevoegen
//