// using NUnit.Framework;
// using Moq;
// using System;
// using AvansDevops.ProjectManagement;

// namespace AvansDevops.Tests.ProjectManagement
// {
//     [TestFixture]
//     public class TestedBacklogItemStateTests
//     {
//         private Mock<BacklogItem> _mockBacklogItem;
//         private Mock<User> _mockUser;
//         private TestedBacklogItemState _state;

//         [SetUp]
//         public void SetUp()
//         {
//             _mockBacklogItem = new Mock<BacklogItem>();
//             _mockUser = new Mock<User>();
//             _mockBacklogItem.Setup(b => b.GetUser()).Returns(_mockUser.Object);

//             _state = new TestedBacklogItemState(_mockBacklogItem.Object);
//         }

//         [Test]
//         public void Complete_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Complete());
//             Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is already tested."));
//         }

//         [Test]
//         public void Start_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
//             Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item that is already tested."));
//         }

//         [Test]
//         public void Reject_UserIsNotLeadDeveloper_ThrowsInvalidOperationException()
//         {
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.Developer); // Not a lead dev

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Reject());
//             Assert.That(ex.Message, Is.EqualTo("Only lead developers can reject a backlog item that is tested."));
//         }

//         [Test]
//         public void Reject_UserIsLeadDeveloper_ChangesStateToReadyForTesting()
//         {
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.LeadDeveloper);

//             _state.Reject();

//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<ReadyForTestingBacklogItemState>()), Times.Once);
//         }

//         [Test]
//         public void Approve_UserIsNotLeadDeveloper_ThrowsInvalidOperationException()
//         {
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.Tester); // Not a lead dev

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Approve());
//             Assert.That(ex.Message, Is.EqualTo("Only lead developers can reject a backlog item that is tested."));
//         }

//         [Test]
//         public void Approve_UserIsLeadDeveloper_ChangesStateToDone()
//         {
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.LeadDeveloper);

//             _state.Approve();

//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<DoneBacklogItemState>()), Times.Once);
//         }
//     }
// }
