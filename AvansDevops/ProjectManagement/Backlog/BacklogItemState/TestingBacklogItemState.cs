namespace AvansDevops.ProjectManagement.Backlog.BacklogItemState;

public class TestingBacklogItemState : IBacklogItemState
{
    private readonly BacklogItem _backlogItem;

    public TestingBacklogItemState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }

    public void Complete()
    {
        throw new InvalidOperationException("Cannot complete a backlog item that is in the Testing state.");
    }

    public void Reject()
    {
        _backlogItem.ChangeState(new TodoBacklogItemState(_backlogItem));
        _backlogItem.GetSprint().NotifyScrumMaster(_backlogItem, "Backlog item has been rejected and moved back to Todo state.");
    }

    public void Approve()
    {
        _backlogItem.ChangeState(new TestedBacklogItemState(_backlogItem));
    }

    public void Start()
    {
        throw new InvalidOperationException("Cannot start a backlog item that is already in the Testing state.");
    }
}