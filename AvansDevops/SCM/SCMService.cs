public class SCMService
{
    private readonly ISCMAdapter _scmAdapter;

    

    public SCMService(ISCMAdapter scmAdapter)
    {
        _scmAdapter = scmAdapter;
    }

    public void Commit(string message)
    {
        _scmAdapter.Commit(message);
    }

    public void Push()
    {
        _scmAdapter.Push();
    }

    public void Pull()
    {
        _scmAdapter.Pull();
    }

    public void CreateBranch(string branchName)
    {
        _scmAdapter.CreateBranch(branchName);
    }
}