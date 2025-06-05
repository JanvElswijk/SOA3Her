public class TestedBacklogItemState : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;

    public TestedBacklogItemState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }

    public void Complete()
    {
        throw new InvalidOperationException("Cannot complete a backlog item that is already tested.");
    }

    public void Reject()
    {
        if (_backlogItem.GetUser()?.GetRole() != UserRole.LeadDeveloper)
        {
            throw new InvalidOperationException("Only lead developers can reject a backlog item that is tested.");
        }
        _backlogItem.ChangeState(new ReadyForTestingBacklogItemState(_backlogItem));
    }

    public void Approve()
    {
        if (_backlogItem.GetUser()?.GetRole() != UserRole.LeadDeveloper)
        {
            throw new InvalidOperationException("Only lead developers can reject a backlog item that is tested.");
        }
        _backlogItem.ChangeState(new DoneBacklogItemState(_backlogItem));
    }

    public void Start()
    {
        throw new InvalidOperationException("Cannot start a backlog item that is already tested.");
    }
}