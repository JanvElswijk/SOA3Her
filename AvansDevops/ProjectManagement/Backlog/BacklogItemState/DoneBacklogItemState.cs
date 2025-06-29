namespace AvansDevops.ProjectManagement.Backlog.BacklogItemState;

public class DoneBacklogItemState: IBacklogItemState
{
    private readonly BacklogItem _backlogItem;

    public DoneBacklogItemState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }

    public void Complete()
    {
        throw new InvalidOperationException("Cannot complete a backlog item that is already done.");
    }

    public void Reject()
    {
        throw new InvalidOperationException("Cannot reject a backlog item that is already done.");
    }

    public void Approve()
    {
        throw new InvalidOperationException("Cannot approve a backlog item that is already done.");
    }

    public void Start()
    {
        throw new InvalidOperationException("Cannot start a backlog item that is already done.");
    }
}