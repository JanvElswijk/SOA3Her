using System.Text;
using AvansDevops.ProjectManagement.Backlog;
using AvansDevops.ProjectManagement.Backlog.BacklogItemState;

namespace AvansDevops.ProjectManagement.Reporting;

public class Report {
    private Sprint.Sprint _sprint;
    private ReportTemplate _template;
    private Dictionary<User, int> _teamPoints = new();

    public Report(Sprint.Sprint sprint) {
        _sprint = sprint;
        
        string header = $"Sprint Report for Sprint {_sprint.Project.Title} - {_sprint._backlogItems._items.Count} Items";
        string footer = $"Report generated on {DateTime.Now} by {_sprint.Project._productOwner.Name}";
        _template = new ReportTemplate(header, footer);
        
        foreach (var user in sprint.Project.Developers) {
            _teamPoints[user] = 0; // Initialize points for each team member
        }
    }

    public Report(Sprint.Sprint sprint, ReportTemplate template) {
        _sprint = sprint;
        _template = template;
        
        foreach (var user in sprint.Project.Developers) {
            _teamPoints[user] = 0; // Initialize points for each team member
        }
    }

    private void Setup() {
        foreach (var user in _sprint.Project.Developers) {
            foreach (BacklogItem b in _sprint._backlogItems._items) {
                if (b.User! == user && b.StoryPoints > 0 && b.State is DoneBacklogItemState) {
                    _teamPoints[user] += b.StoryPoints;
                }
            }
        }
    }

    public string Generate() {
        Setup();
        
        StringBuilder reportBuilder = new StringBuilder();
        
        reportBuilder.AppendLine(_template.Header);
        if (!string.IsNullOrEmpty(_template.Logo)) {
            reportBuilder.AppendLine($"Logo: {_template.Logo}");
        }
        reportBuilder.AppendLine("Team Members and Points Earned:");
        foreach (var kvp in _teamPoints) {
            reportBuilder.AppendLine($"{kvp.Key.Name}: {kvp.Value} points");
        }
        reportBuilder.AppendLine("Sprint Backlog Items:");
        foreach (var item in _sprint._backlogItems._items) {
            reportBuilder.AppendLine($"- {item.Title} (State: {item.State.GetType().Name}, Story Points: {item.StoryPoints})");
        }
        
        reportBuilder.AppendLine("Burndown Chart:");
        reportBuilder.AppendLine("--------------------");
        reportBuilder.AppendLine("---BURNDOWN CHART---");
        reportBuilder.AppendLine("--------------------");
        
        int totalStoryPoints = _sprint._backlogItems._items.Sum(i => i.StoryPoints);
        int completedStoryPoints = _teamPoints.Values.Sum();
        int remainingStoryPoints = totalStoryPoints - completedStoryPoints;
        reportBuilder.AppendLine($"Total Story Points: {totalStoryPoints}");
        reportBuilder.AppendLine($"Completed Story Points: {completedStoryPoints}");
        reportBuilder.AppendLine($"Remaining Story Points: {remainingStoryPoints}");
        reportBuilder.AppendLine("--------------------");
        
        reportBuilder.AppendLine(_template.Footer);
        if (!string.IsNullOrEmpty(_template.Logo)) {
            reportBuilder.AppendLine($"Logo: {_template.Logo}");
        }

        return reportBuilder.ToString();
    }

    public static void SaveToFile(string report, string filePath, ReportFormat reportFormat) {
        switch (reportFormat) {
            case ReportFormat.Text:
                System.IO.File.WriteAllText(filePath, report);
                break;
            case ReportFormat.Pdf:
                Console.WriteLine("PDF saving is not implemented yet, saving as text instead.");
                File.WriteAllText(filePath, report);
                break;
            case ReportFormat.Png:
                Console.WriteLine("PNG saving is not implemented yet, saving as text instead.");
                File.WriteAllText(filePath, report);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(reportFormat), reportFormat, null);
        }
    }
}

public enum ReportFormat {
    Text,
    Pdf,
    Png
}