using AvansDevops.DevOps;
namespace AvansDevops.ProjectManagement;

public interface ISprintStrategy
{
    public bool? Execute(Pipeline pipeline, string? summary);
}