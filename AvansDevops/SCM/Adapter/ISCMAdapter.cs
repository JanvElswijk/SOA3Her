namespace AvansDevops.SCM.Adapter;

public interface ISCMAdapter
{
    void Commit(string message);
    void Push();
    void Pull();
    void CreateBranch(string branchName);
}