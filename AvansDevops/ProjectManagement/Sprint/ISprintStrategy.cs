using AvansDevops.DevOps;

public interface ISprintStrategy
{
    public bool? Execute(Pipeline pipeline, string? summary);
}