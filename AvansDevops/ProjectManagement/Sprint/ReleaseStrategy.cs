using AvansDevops.DevOps;

namespace AvansDevops.ProjectManagement;

public class ReleaseStrategy : ISprintStrategy
{

    //moet run pipeline
    public bool? Execute(Pipeline pipeline, string? summary)
    {
        IPipelineVisitor visitor = new DevOpsPipelineVisitor();
       return  pipeline.Execute(visitor);
    }
}