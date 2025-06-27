using Moq;
using NUnit.Framework;

[TestFixture]
public class SCMServiceTests
{
    [Test]
    public void Commit_CallsAdapterCommit()
    {
        var mock = new Mock<ISCMAdapter>();
        var service = new SCMService(mock.Object);

        service.Commit("msg");

        mock.Verify(a => a.Commit("msg"), Times.Once);
    }

    [Test]
    public void Push_CallsAdapterPush()
    {
        var mock = new Mock<ISCMAdapter>();
        var service = new SCMService(mock.Object);

        service.Push();

        mock.Verify(a => a.Push(), Times.Once);
    }
    [Test]
    public void Pull_CallsAdapterPull()
    {
        var mock = new Mock<ISCMAdapter>();
        var service = new SCMService(mock.Object);

        service.Pull();

        mock.Verify(a => a.Pull(), Times.Once);
    }
    
    [Test]
    public void CreateBranch_CallsAdapterCreateBranch()
    {
        var mock = new Mock<ISCMAdapter>();
        var service = new SCMService(mock.Object);

        service.CreateBranch("new-branch");

        mock.Verify(a => a.CreateBranch("new-branch"), Times.Once);
    }
}