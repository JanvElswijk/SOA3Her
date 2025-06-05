public class TodoBacklogItemState : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;

    public TodoBacklogItemState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }
    public void Complete()
    {
        throw new InvalidOperationException("Cannot complete a backlog item in the Todo state.");
    }

    public void Reject()
    {
        throw new InvalidOperationException("Cannot reject a backlog item in the Todo state.");
    }

    public void Approve()
    {
        throw new InvalidOperationException("Cannot approve a backlog item in the Todo state.");
    }

    public void Start()
    {
        if (_backlogItem.GetUser() == null)
        {
            throw new InvalidOperationException("Cannot start a backlog item in the Todo state without a developer assigned.");
        }

         if (_backlogItem.GetUser().GetRole() != UserRole.Developer)
        {
            throw new InvalidOperationException("Only developers can start a backlog item in the Todo state.");
        }
        
        _backlogItem.ChangeState(new DoingBacklogItemState(_backlogItem));
    }
}