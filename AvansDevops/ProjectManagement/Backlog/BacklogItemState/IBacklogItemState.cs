namespace AvansDevops.ProjectManagement.Backlog.BacklogItemState;

public interface IBacklogItemState
{
    void Complete();
    void Reject();
    void Approve();
    void Start();
}