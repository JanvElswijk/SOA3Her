namespace AvansDevops.ProjectManagement;
public class Backlog
{
    public List<BacklogItem> _items;



    public Backlog()
    {
        _items = new List<BacklogItem>();
    }

    //todo
    public void AddBacklogItem(BacklogItem item)
    {

        if (_items.Contains(item))
        {
            throw new InvalidOperationException("Backlog item already exists in the backlog.");
        }
        _items.Add(item);
    }
}