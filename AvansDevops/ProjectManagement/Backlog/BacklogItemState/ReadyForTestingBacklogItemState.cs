using AvansDevops.ProjectManagement;
public class ReadyForTestingBacklogItemState : IBacklogItemState
{

    //Testers kunnen het oppakken, voeg user toe

    private readonly BacklogItem _backlogItem;

    public ReadyForTestingBacklogItemState(BacklogItem backlogItem)
    {
        _backlogItem = backlogItem;
    }

    public void Complete()
    {
        throw new InvalidOperationException("Cannot complete a backlog item that is ready for testing.");
    }

    public void Reject()
    {
        throw new InvalidOperationException("Cannot reject a backlog item that is ready for testing.");
    }

    public void Approve()
    {
        throw new InvalidOperationException("Cannot approve a backlog item that is ready for testing.");
    }

    public void Start()
    {
        if (_backlogItem.GetUser().GetRole() != UserRole.Tester)
        {
            throw new InvalidOperationException("Only testers can start a backlog item that is ready for testing.");
        }

        _backlogItem.ChangeState(new TestingBacklogItemState(_backlogItem));
    }
}