namespace AvansDevops.ProjectManagement.Reporting;

public class ReportTemplate(string header, string footer, string? logo = null) {
    public string Header { get; set; } = header;
    public string Footer { get; set; } = footer;
    public string? Logo { get; set; } = null;
}