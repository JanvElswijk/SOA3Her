public class DoingBacklogItemState : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;


    public DoingBacklogItemState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }

    public void Approve()
    {
        throw new InvalidOperationException("Cannot approve a backlog item that is in progress.");
    }

    public void Complete()
    {
        _backlogItem.ChangeState(new ReadyForTestingBacklogItemState(_backlogItem));
        _backlogItem.GetSprint().NotifyTesters(_backlogItem, "Backlog item has been completed and moved to Ready for Testing state.");
    }

    public void Reject()
    {
        throw new InvalidOperationException("Cannot reject a backlog item that is in progress.");
    }

    public void Start()
    {
        throw new InvalidOperationException("Cannot start a backlog item that is in progress.");
    }
}

