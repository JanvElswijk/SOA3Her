using System.Collections.Generic;

public class BacklogItem
{
    private List<INotificationObserver> Observers { get; set; } = new List<INotificationObserver>();
    public string title { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public int storyPoints { get; set; }
    public List<BacklogItem> activities { get; set; } = new List<BacklogItem>();

    public BacklogItem(string title, string description, string status, int storyPoints)
    {
        this.title = title;
        this.description = description;
        this.status = status;
        this.storyPoints = storyPoints;
    }

    public void AddObserver(INotificationObserver observer)
    {
        Observers.Add(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in Observers)
        {
            observer.Update(this);
        }
    }
}
