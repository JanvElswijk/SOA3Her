using AvansDevops.DevOps;

public class ReleaseStrategy : ISprintStrategy
{

    //moet run pipeline
    public bool? Execute(Pipeline pipeline, string? summary)
    {
        IPipelineVisitor visitor = new DevOpsPipelineVisitor();
       return  pipeline.Execute(visitor);
    }
}