using AvansDevops.DevOps;

public class ReviewStrategy : ISprintStrategy
{
    //Kan pipeline runnen, bijv alleen test

    //Maken dat je niet per se een pipeline nodig hebt
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