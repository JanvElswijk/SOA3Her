namespace AvansDevops.DevOps.Utility;

public class FileActivity : UtilityActivity
{
    private readonly FileOperation _operation;
    private readonly string? _sourcePath;
    private readonly string? _destinationPath;
    private readonly string? _url;
    
    /// <summary>
    /// Constructor for file copy operation.
    /// </summary>
    /// <param name="sourcePath"></param>
    /// <param name="destinationPath"></param>
    public FileActivity(string sourcePath, string destinationPath)
    {
        _operation = FileOperation.Copy;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    /// <summary>
    /// Constructor for file delete operation.
    /// </summary>
    /// <param name="sourcePath"></param>
    public FileActivity(string sourcePath)
    {
        _operation = FileOperation.Delete;
        _sourcePath = sourcePath;
    }

    /// <summary>
    /// Constructor for file download operation.
    /// </summary>
    /// <param name="url"></param>
    public FileActivity(Uri url)
    {
        _operation = FileOperation.Download;
        _url = url.ToString();
    }
    public override bool RunUtility() {
        switch (_operation) {
            case FileOperation.Copy:
                Console.WriteLine($"[DEVOPS : Utility] Copying file from: {_sourcePath} to: {_destinationPath}");
                return true;
            case FileOperation.Delete:
                Console.WriteLine($"[DEVOPS : Utility] Deleting file at: {_sourcePath}");
                return true;
            case FileOperation.Download:
                Console.WriteLine($"[DEVOPS : Utility] Downloading file from URL: {_url}");
                return true;
            default:
                Console.WriteLine("[DEVOPS : Utility] Unknown file operation");
                return false;
        }
    }
    
    private enum FileOperation
    {
        Copy,
        Delete,
        Download
    }
}