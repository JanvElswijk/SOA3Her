using AvansDevops.DevOps;

public class ReviewStrategy : ISprintStrategy
{
    public bool? Execute(Pipeline pipeline, string? summary)
    {
        if (string.IsNullOrWhiteSpace(summary))
        {
            Console.WriteLine("Please add summary.");
            return null;
        }

        if (pipeline == null)
        {
            Console.WriteLine("Finished sprint without pipeline");
            return null;
        }

        var visitor = new DevOpsPipelineVisitor();
        return pipeline.Execute(visitor);
    }
}
