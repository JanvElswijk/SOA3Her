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
        if (_items == null)
        {
            _items = new List<BacklogItem>();
        }
        _items.Add(item);
    }
}