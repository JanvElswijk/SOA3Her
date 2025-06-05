namespace AvansDevops.DevOps;

public class ActivityComposite : Activity {
    protected readonly List<Activity> Activities = [];
    
    public override bool Execute(IPipelineVisitor visitor) {
        foreach (var c in Activities) {
            if (!c.Execute(visitor)) {
                return false;
            }
        }
        return true;
    }
    
    public void Add(Activity activity) {
        Activities.Add(activity);
    }
    
    public void AddAll(IEnumerable<Activity> activities) {
        Activities.AddRange(activities);
    }
    
    public Activity GetChild(int index) {
        // TODO: Error handling for index out of range
        return Activities[index];
    }
}