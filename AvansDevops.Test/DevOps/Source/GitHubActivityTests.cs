using AvansDevops.DevOps.Source;

namespace AvansDevops.Test.DevOps.Source;

[TestFixture]
public class GitHubActivityTests

{
    [Test]
    public void GetSourceCodeShouldReturnTrue()
    {
        // Arrange
        var activity = new GitLabActivity("github.com/repository/test");

        // Act
        var result = activity.GetSourceCode();

        // Assert
        Assert.That(result, Is.True);
    }
}