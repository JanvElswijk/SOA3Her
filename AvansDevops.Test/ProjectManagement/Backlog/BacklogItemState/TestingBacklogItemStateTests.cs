// using NUnit.Framework;
// using Moq;
// using System;
// using AvansDevops.ProjectManagement;

// namespace AvansDevops.Tests.ProjectManagement
// {
//     [TestFixture]
//     public class TestingBacklogItemStateTests
//     {
//         private Mock<BacklogItem> _mockBacklogItem;
//         private Mock<Sprint> _mockSprint;
//         private TestingBacklogItemState _state;

//         [SetUp]
//         public void SetUp()
//         {
//             _mockBacklogItem = new Mock<BacklogItem>();
//             _mockSprint = new Mock<Sprint>();

//             _mockBacklogItem.Setup(b => b.GetSprint()).Returns(_mockSprint.Object);

//             _state = new TestingBacklogItemState(_mockBacklogItem.Object);
//         }

//         [Test]
//         public void Complete_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Complete());
//             Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is in the Testing state."));
//         }

//         [Test]
//         public void Start_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
//             Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already in the Testing state."));
//         }

//         [Test]
//         public void Reject_ChangesStateToTodoAndNotifiesScrumMaster()
//         {
//             // Act
//             _state.Reject();

//             // Assert
//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<TodoBacklogItemState>()), Times.Once);
//             _mockSprint.Verify(s => s.NotifyScrumMaster(_mockBacklogItem.Object, 
//                 "Backlog item has been rejected and moved back to Todo state."), Times.Once);
//         }

//         [Test]
//         public void Approve_ChangesStateToTested()
//         {
//             // Act
//             _state.Approve();

//             // Assert
//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<TestedBacklogItemState>()), Times.Once);
//         }
//     }
// }
