using AvansDevops.DevOps;

public interface ISprintStrategy
{
    public void Execute(Pipeline pipeline, string? summary);
}