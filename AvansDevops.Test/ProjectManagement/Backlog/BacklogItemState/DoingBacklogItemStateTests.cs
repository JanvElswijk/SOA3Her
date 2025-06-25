// using NUnit.Framework;
// using Moq;
// using System;
// using AvansDevops.ProjectManagement;
// using AvansDevops.Notifications.Adapter;

// namespace AvansDevops.Tests.ProjectManagement
// {
//     [TestFixture]
//     public class DoingBacklogItemStateTests
//     {
//         private Mock<BacklogItem> _mockBacklogItem;
//         private Mock<Sprint> _mockSprint;
//         private DoingBacklogItemState _state;

//         [SetUp]
//         public void SetUp()
//         {
//             _mockBacklogItem = new Mock<BacklogItem>();
//             _mockSprint = new Mock<Sprint>();

//             _mockBacklogItem.Setup(b => b.GetSprint()).Returns(_mockSprint.Object);

//             _state = new DoingBacklogItemState(_mockBacklogItem.Object);
//         }

//         [Test]
//         public void Approve_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Approve());
//             Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item that is in progress."));
//         }

//         [Test]
//         public void Reject_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Reject());
//             Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item that is in progress."));
//         }

//         [Test]
//         public void Start_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
//             Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already in progress."));
//         }

//         [Test]
//         public void Complete_ChangesStateAndNotifiesTesters()
//         {
//             // Act
//             _state.Complete();

//             // Assert
//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<ReadyForTestingBacklogItemState>()), Times.Once);
//             _mockBacklogItem.Verify(b => b.GetSprint(), Times.Once);
//             _mockSprint.Verify(s => s.NotifyTesters(_mockBacklogItem.Object, 
//                 "Backlog item has been completed and moved to Ready for Testing state."), Times.Once);
//         }
//     }
// }
