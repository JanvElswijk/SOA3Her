using AvansDevops.DevOps;

public class ReviewStrategy : ISprintStrategy
{
    //Kan pipeline runnen, bijv alleen test
    public bool? Execute(Pipeline pipeline, string? summary)
    {
        if (string.IsNullOrWhiteSpace(summary))
        {
            Console.WriteLine("Please add summary.");
            return null;
        }
        else
        {
            IPipelineVisitor visitor = new DevOpsPipelineVisitor();
            return pipeline.Execute(visitor);

        }
    }
}