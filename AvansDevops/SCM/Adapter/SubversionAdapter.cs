namespace AvansDevops.SCM.Adapter;

public class SubversionAdapter : ISCMAdapter
{
    public void Commit(string message)
    {
        Console.WriteLine($"[SCM] Committing changes with message: {message}");
    }

    public void Push()
    {
        Console.WriteLine("[SCM] Pushing changes to the remote Subversion repository.");
    }

    public void Pull()
    {
        Console.WriteLine($"[SCM] Pulling changes.");
    }

    public void CreateBranch(string branchName)
    {
        Console.WriteLine($"[SCM] Creating new branch: {branchName}");
    }
}