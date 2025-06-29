namespace AvansDevops.ProjectManagement.Backlog.BacklogItemState;

public class NotInSprintBacklogItemState : IBacklogItemState
{
    
    public void Complete()
    {
        throw new InvalidOperationException("Cannot complete a backlog item that is not in the sprint.");
    }

    public void Reject()
    {
        throw new InvalidOperationException("Cannot reject a backlog item that is not in the sprint.");
    }

    public void Approve()
    {
        throw new InvalidOperationException("Cannot approve a backlog item that is not in the sprint.");
    }

    public void Start()
    {
        throw new InvalidOperationException("Cannot start a backlog item that is not in the sprint.");
    }
}