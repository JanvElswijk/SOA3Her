using AvansDevops.DevOps;

public class ReviewStrategy : ISprintStrategy
{
    //Kan pipeline runnen, bijv alleen test
    public void Execute(Pipeline pipeline, string? summary)
    {   
        if (string.IsNullOrWhiteSpace(summary))
        {
            Console.WriteLine("Please add summary.");
        }
        else
        {
            IPipelineVisitor visitor = new DevOpsPipelineVisitor();
            pipeline.Execute(visitor);

        }
    }
}