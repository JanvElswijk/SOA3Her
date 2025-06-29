// using System;
// using System.Collections.Generic;
// using System.IO;
// using AvansDevops.ProjectManagement;
// using AvansDevops.ProjectManagement.Project;
// using Moq;
// using AvansDevops.ProjectManagement.Reporting;
// using AvansDevops.ProjectManagement.Sprint;
//
// namespace AvansDevops.Test.ProjectManagement.Reporting
// {
//     [TestFixture]
//     public class ReportTests
//     {
//         private Mock<Sprint> _mockSprint;
//         private Mock<Project> _mockProject;
//         private Mock<User> _mockUser1;
//         private Mock<User> _mockUser2;
//         private List<BacklogItem> _backlogItems;
//         private BacklogItem _backlogItemsWrapper;
//
//         [SetUp]
//         public void SetUp()
//         {
//             _mockSprint = new Mock<Sprint>();
//             _mockProject = new Mock<Project>();
//             _mockUser1 = new Mock<User>();
//             _mockUser2 = new Mock<User>();
//
//             _mockUser1.Setup(u => u.Name).Returns("Alice");
//             _mockUser2.Setup(u => u.Name).Returns("Bob");
//
//             _mockSprint.Setup(s => s.Project).Returns(_mockProject.Object);
//             _mockSprint.Setup(s => s._backlogItems).Returns(new Backlog { _items = new List<BacklogItem>() });
//
//             _backlogItems = new List<BacklogItem>
//             {
//                 new BacklogItem("Item 1", "Description for Item 1", 5),
//                 new BacklogItem("Item 2", "Description for Item 2", 3),
//                 new BacklogItem("Item 3", "Description for Item 3", 2)
//             };
//
//             _backlogItems[0].SetUser(_mockUser1.Object);
//             _backlogItems[1].SetUser(_mockUser2.Object);
//             _backlogItems[2].SetUser(_mockUser1.Object);
//             
//             foreach (var item in _backlogItems)
//             {
//                 _mockSprint.Object._backlogItems._items.Add(item);
//             }
//             
//             _backlogItems[0].ChangeState(new DoneBacklogItemState(_backlogItems[0]));
//             _backlogItems[1].ChangeState(new DoneBacklogItemState(_backlogItems[1]));
//             _backlogItems[2].ChangeState(new TodoBacklogItemState(_backlogItems[2]));
//             
//             _mockProject.Setup(p => p.Title).Returns("Sprint Test Project");
//         }
//
//         [Test]
//         public void Generate_ShouldIncludeTeamPointsAndBacklogItems()
//         {
//             // Arrange
//             var report = new Report(_mockSprint.Object);
//
//             // Act
//             var result = report.Generate();
//
//             // Assert
//             Assert.That(result, Does.Contain("Alice: 5 points"));
//             Assert.That(result, Does.Contain("Bob: 3 points"));
//             Assert.That(result, Does.Contain("Item 1"));
//             Assert.That(result, Does.Contain("Item 2"));
//             Assert.That(result, Does.Contain("Item 3"));
//             Assert.That(result, Does.Contain("Sprint Report for Sprint Test Project"));
//         }
//
//         [Test]
//         public void SaveToFile_ShouldWriteTextFile()
//         {
//             // Arrange
//             var tempFile = Path.GetTempFileName();
//             var content = "Test Report Content";
//
//             // Act
//             Report.SaveToFile(content, tempFile, ReportFormat.Text);
//
//             // Assert
//             var fileContent = File.ReadAllText(tempFile);
//             Assert.That(fileContent, Is.EqualTo(content));
//
//             File.Delete(tempFile);
//         }
//
//         [Test]
//         public void SaveToFile_WithPdfOrPng_ShouldWriteTextFile()
//         {
//             var tempFile = Path.GetTempFileName();
//             var content = "Test PDF/PNG Content";
//
//             Report.SaveToFile(content, tempFile, ReportFormat.Pdf);
//             Assert.That(File.ReadAllText(tempFile), Is.EqualTo(content));
//
//             Report.SaveToFile(content, tempFile, ReportFormat.Png);
//             Assert.That(File.ReadAllText(tempFile), Is.EqualTo(content));
//
//             File.Delete(tempFile);
//         }
//     }
// }