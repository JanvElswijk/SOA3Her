using NUnit.Framework;
using Moq;

    [TestFixture]
    public class SCMServiceTests
    {
        [Test]
        public void Commit_CallsAdapterCommit()
        {
            // Arrange
            var mockAdapter = new Mock<ISCMAdapter>();
            var service = new SCMService(mockAdapter.Object);
            string message = "Test commit";

            // Act
            service.Commit(message);

            // Assert
            mockAdapter.Verify(a => a.Commit(message), Times.Once);
        }

        [Test]
        public void Push_CallsAdapterPush()
        {
            // Arrange
            var mockAdapter = new Mock<ISCMAdapter>();
            var service = new SCMService(mockAdapter.Object);

            // Act
            service.Push();

            // Assert
            mockAdapter.Verify(a => a.Push(), Times.Once);
        }

        [Test]
        public void Pull_CallsAdapterPull()
        {
            // Arrange
            var mockAdapter = new Mock<ISCMAdapter>();
            var service = new SCMService(mockAdapter.Object);

            // Act
            service.Pull();

            // Assert
            mockAdapter.Verify(a => a.Pull(), Times.Once);
        }

        [Test]
        public void CreateBranch_CallsAdapterCreateBranch()
        {
            // Arrange
            var mockAdapter = new Mock<ISCMAdapter>();
            var service = new SCMService(mockAdapter.Object);
            string branchName = "feature/test";

            // Act
            service.CreateBranch(branchName);

            // Assert
            mockAdapter.Verify(a => a.CreateBranch(branchName), Times.Once);
        }
    }