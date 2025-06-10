using AvansDevops.DevOps;

public class ReleaseStrategy : ISprintStrategy
{

    //moet run pipeline
    public void Execute(Pipeline pipeline, string? summary)
    {
        IPipelineVisitor visitor = new DevOpsPipelineVisitor();
        pipeline.Execute(visitor);

        

    }
}