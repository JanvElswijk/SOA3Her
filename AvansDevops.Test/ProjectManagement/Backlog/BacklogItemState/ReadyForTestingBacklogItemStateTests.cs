// using NUnit.Framework;
// using Moq;
// using System;
// using AvansDevops.ProjectManagement;

// namespace AvansDevops.Tests.ProjectManagement
// {
//     [TestFixture]
//     public class ReadyForTestingBacklogItemStateTests
//     {
//         private Mock<BacklogItem> _mockBacklogItem;
//         private Mock<User> _mockUser;
//         private ReadyForTestingBacklogItemState _state;

//         [SetUp]
//         public void SetUp()
//         {
//             _mockBacklogItem = new Mock<BacklogItem>();
//             _mockUser = new Mock<User>();
//             _mockBacklogItem.Setup(b => b.GetUser()).Returns(_mockUser.Object);
//         }

//         [Test]
//         public void Complete_ThrowsInvalidOperationException()
//         {
//             _state = new ReadyForTestingBacklogItemState(_mockBacklogItem.Object);

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Complete());
//             Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item that is ready for testing."));
//         }

//         [Test]
//         public void Reject_ThrowsInvalidOperationException()
//         {
//             _state = new ReadyForTestingBacklogItemState(_mockBacklogItem.Object);

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Reject());
//             Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item that is ready for testing."));
//         }

//         [Test]
//         public void Approve_ThrowsInvalidOperationException()
//         {
//             _state = new ReadyForTestingBacklogItemState(_mockBacklogItem.Object);

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Approve());
//             Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item that is ready for testing."));
//         }

//         [Test]
//         public void Start_UserIsNotTester_ThrowsInvalidOperationException()
//         {
//             // Arrange
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.Developer); // or anything not Tester
//             _state = new ReadyForTestingBacklogItemState(_mockBacklogItem.Object);

//             // Act & Assert
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
//             Assert.That(ex.Message, Is.EqualTo("Only testers can start a backlog item that is ready for testing."));
//         }

//         [Test]
//         public void Start_UserIsTester_ChangesStateToDoingBacklogItemState()
//         {
//             // Arrange
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.Tester);
//             _state = new ReadyForTestingBacklogItemState(_mockBacklogItem.Object);

//             // Act
//             _state.Start();

//             // Assert
//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<DoingBacklogItemState>()), Times.Once);
//         }
//     }
// }
