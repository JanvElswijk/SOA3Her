using AvansDevops.ProjectManagement;
using AvansDevops.ProjectManagement.Backlog;
using AvansDevops.ProjectManagement.Backlog.BacklogItemState;
using AvansDevops.ProjectManagement.Reporting;
using AvansDevops.ProjectManagement.Sprint;
using AvansDevops.SCM;
using AvansDevops.SCM.Adapter;
using Moq;

namespace AvansDevops.Test.ProjectManagement.Reporting;

[TestFixture]
public class ReportTests
{
    private AvansDevops.ProjectManagement.Sprint.Sprint _sprint;
    private User _developer;
    private BacklogItem _backlogItem;
    private AvansDevops.ProjectManagement.Backlog.Backlog _backlog;



    [SetUp]
    public void SetUp()
    {
        // Create test data
        _developer = new User("Dev1", "dev1@example.com", UserRole.Developer);
        var developers = new List<User> { _developer };
        var productOwner = new User("PO", "po@example.com", UserRole.ProductOwner);
        
        var mockAdapter = new Mock<ISCMAdapter>();
        var scmService = new SCMService(mockAdapter.Object);
        var project = new AvansDevops.ProjectManagement.Project.Project("Test Project", scmService, developers, productOwner);
        
        _backlog = new AvansDevops.ProjectManagement.Backlog.Backlog();
        _backlogItem = new BacklogItem("Test Item", "Description", 5);
        _backlogItem.SetUser(_developer);
        _backlogItem.ChangeState(new TodoBacklogItemState(_backlogItem));
        _backlog.AddBacklogItem(_backlogItem);

        
        // _backlogItem.ChangeState(new DoneBacklogItemState(_backlogItem)); // Set item to done for testing



        var leadDev = new User("Lead", "lead@example.com", UserRole.LeadDeveloper);
        var testers = new List<User>();
        var scrumMaster = new User("SM", "sm@example.com", UserRole.ScrumMaster);
        var strategy = new Mock<ISprintStrategy>().Object;

        _sprint = new AvansDevops.ProjectManagement.Sprint.Sprint(project, _backlog, leadDev, testers, scrumMaster, strategy, null);
    }

    // Constructor Tests (CC = 1 each)
    [Test]
    public void Constructor_WithSprint_InitializesCorrectly()
    {
        // Act
        var report = new AvansDevops.ProjectManagement.Reporting.Report(_sprint);

        // Assert
        Assert.That(report, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithSprintAndTemplate_InitializesCorrectly()
    {
        // Arrange
        var template = new ReportTemplate("Header", "Footer");

        // Act
        var report = new AvansDevops.ProjectManagement.Reporting.Report(_sprint, template);

        // Assert
        Assert.That(report, Is.Not.Null);
    }

    // Setup Tests (CC = 3) - Tests the nested loops and conditions
    [Test]
    public void Setup_WithDoneBacklogItems_CalculatesPointsCorrectly()
    {
        // Arrange
        _backlogItem.ChangeState(new DoneBacklogItemState(_backlogItem)); // Set item to done

        var report = new AvansDevops.ProjectManagement.Reporting.Report(_sprint);


        // Act
        var result = report.Generate();



        // Assert
        Assert.That(result, Does.Contain("Dev1: 5 points"));
    }

    [Test]
    public void Setup_WithNonDoneBacklogItems_DoesNotCountPoints()
    {
        // Arrange
        _backlogItem.ChangeState(new TodoBacklogItemState(_backlogItem));
        var report = new AvansDevops.ProjectManagement.Reporting.Report(_sprint);

        // Act
        var result = report.Generate();

        // Assert
        Assert.That(result, Does.Contain("Dev1: 0 points"));
    }

    // Generate Tests (CC = 2) - Tests the Logo condition
    [Test]
    public void Generate_WithoutLogo_GeneratesReportWithoutLogo()
    {
        // Arrange
        var report = new AvansDevops.ProjectManagement.Reporting.Report(_sprint);

        // Act
        var result = report.Generate();

        // Assert
        Assert.That(result, Does.Contain("Test Project"));
        Assert.That(result, Does.Contain("Team Members and Points Earned:"));
        Assert.That(result, Does.Not.Contain("Logo:"));
    }

    [Test]
    public void Generate_WithLogo_GeneratesReportWithLogo()
    {
        // Arrange
        var template = new ReportTemplate("Header", "Footer") { Logo = "TestLogo" };
        var report = new AvansDevops.ProjectManagement.Reporting.Report(_sprint, template);

        // Act
        var result = report.Generate();

        // Assert
        Assert.That(result, Does.Contain("Logo: TestLogo"));
    }

    // SaveToFile Tests (CC = 4) - Tests all switch cases
    [Test]
    public void SaveToFile_WithTextFormat_SavesFile()
    {
        // Arrange
        string tempFile = Path.GetTempFileName();
        string content = "Test report content";

        try
        {
            // Act
            AvansDevops.ProjectManagement.Reporting.Report.SaveToFile(content, tempFile, ReportFormat.Text);

            // Assert
            Assert.That(File.Exists(tempFile), Is.True);
            Assert.That(File.ReadAllText(tempFile), Is.EqualTo(content));
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
    }

    [Test]
    public void SaveToFile_WithPdfFormat_SavesAsText()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);

        string tempFile = Path.GetTempFileName();
        string content = "Test report content";

        try
        {
            // Act & Assert
            Assert.DoesNotThrow(() => AvansDevops.ProjectManagement.Reporting.Report.SaveToFile(content, tempFile, ReportFormat.Pdf));
            Assert.That(File.Exists(tempFile), Is.True);
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }

        output.Close();
    }

    [Test]
    public void SaveToFile_WithPngFormat_SavesAsText()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        string tempFile = Path.GetTempFileName();
        string content = "Test report content";

        try
        {
            // Act & Assert
            Assert.DoesNotThrow(() => AvansDevops.ProjectManagement.Reporting.Report.SaveToFile(content, tempFile, ReportFormat.Png));
            Assert.That(File.Exists(tempFile), Is.True);
        }
        finally
        {
            if (File.Exists(tempFile)) File.Delete(tempFile);
        }
        output.Close();
    }

    [Test]
    public void SaveToFile_WithInvalidFormat_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => 
            AvansDevops.ProjectManagement.Reporting.Report.SaveToFile("content", "file.txt", (ReportFormat)999));
    }
}