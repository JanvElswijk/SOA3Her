using NUnit.Framework;
using AvansDevops.ProjectManagement;
using Moq;
using AvansDevops.ProjectManagement.Sprint;

[TestFixture]
    public class BacklogItemTestsTest
    {
        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            var item = new BacklogItem("Title", "Description", 5);

            Assert.That(item, Is.Not.Null);
            Assert.That(item.GetSprint(), Is.Null);
            Assert.That(item.GetUser(), Is.Null);
        }

        [Test]
        public void SetSprint_ShouldAssignSprintAndChangeStateToTodo()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var sprint = new Sprint();

            item.SetSprint(sprint);

            Assert.That(sprint, Is.EqualTo(item.GetSprint()));
            Assert.That(item.State, Is.InstanceOf<TodoBacklogItemState>());
        }

 

    [Test]
        public void ChangeState_ShouldUpdateState()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var newState = new Mock<IBacklogItemState>().Object;

            item.ChangeState(newState);

            Assert.That(newState, Is.EqualTo(item.State));
        }

        [Test]
        public void SetUser_ShouldAssignUser()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var user = new User();

            item.SetUser(user);

            Assert.That(user, Is.EqualTo(item.GetUser()));
        }

        [Test]
        public void GetUser_ShouldReturnNullIfNotSet()
        {
            var item = new BacklogItem("Title", "Description", 5);

            Assert.That(item.GetUser(), Is.Null);
        }

        [Test]
        public void Start_ShouldCallStateStart()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var stateMock = new Mock<IBacklogItemState>();
            item.ChangeState(stateMock.Object);

            item.Start();

            stateMock.Verify(s => s.Start(), Times.Once);
        }

        [Test]
        public void Complete_ShouldCallStateComplete()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var stateMock = new Mock<IBacklogItemState>();
            item.ChangeState(stateMock.Object);

            item.Complete();

            stateMock.Verify(s => s.Complete(), Times.Once);
        }

        [Test]
        public void Reject_ShouldCallStateReject()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var stateMock = new Mock<IBacklogItemState>();
            item.ChangeState(stateMock.Object);

            item.Reject();

            stateMock.Verify(s => s.Reject(), Times.Once);
        }

        [Test]
        public void Approve_ShouldCallStateApprove()
        {
            var item = new BacklogItem("Title", "Description", 5);
            var stateMock = new Mock<IBacklogItemState>();
            item.ChangeState(stateMock.Object);

            item.Approve();
        stateMock.Verify(s => s.Approve(), Times.Once);
        }
    }


 