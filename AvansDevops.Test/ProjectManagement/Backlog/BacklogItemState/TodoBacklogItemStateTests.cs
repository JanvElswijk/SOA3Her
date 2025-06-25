// using NUnit.Framework;
// using Moq;
// using System;
// using AvansDevops.ProjectManagement;

// namespace AvansDevops.Tests.ProjectManagement
// {
//     [TestFixture]
//     public class TodoBacklogItemStateTests
//     {
//         private Mock<BacklogItem> _mockBacklogItem;
//         private Mock<User> _mockUser;
//         private TodoBacklogItemState _state;

//         [SetUp]
//         public void SetUp()
//         {
//             _mockBacklogItem = new Mock<BacklogItem>();
//             _mockUser = new Mock<User>();

//             _state = new TodoBacklogItemState(_mockBacklogItem.Object);
//         }

//         [Test]
//         public void Complete_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Complete());
//             Assert.That(ex.Message, Is.EqualTo("Cannot complete a backlog item in the Todo state."));
//         }

//         [Test]
//         public void Reject_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Reject());
//             Assert.That(ex.Message, Is.EqualTo("Cannot reject a backlog item in the Todo state."));
//         }

//         [Test]
//         public void Approve_ThrowsInvalidOperationException()
//         {
//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Approve());
//             Assert.That(ex.Message, Is.EqualTo("Cannot approve a backlog item in the Todo state."));
//         }

//         [Test]
//         public void Start_WithoutUserAssigned_ThrowsInvalidOperationException()
//         {
//             _mockBacklogItem.Setup(b => b.GetUser()).Returns((User)null);

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
//             Assert.That(ex.Message, Is.EqualTo("Cannot start a backlog item in the Todo state without a developer assigned."));
//         }

//         [Test]
//         public void Start_WithNonDeveloperUser_ThrowsInvalidOperationException()
//         {
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.Tester);
//             _mockBacklogItem.Setup(b => b.GetUser()).Returns(_mockUser.Object);

//             var ex = Assert.Throws<InvalidOperationException>(() => _state.Start());
//             Assert.That(ex.Message, Is.EqualTo("Only developers can start a backlog item in the Todo state."));
//         }

//         [Test]
//         public void Start_WithDeveloperUser_ChangesStateToDoing()
//         {
//             _mockUser.Setup(u => u.GetRole()).Returns(UserRole.Developer);
//             _mockBacklogItem.Setup(b => b.GetUser()).Returns(_mockUser.Object);

//             _state.Start();

//             _mockBacklogItem.Verify(b => b.ChangeState(It.IsAny<DoingBacklogItemState>()), Times.Once);
//         }
//     }
// }
