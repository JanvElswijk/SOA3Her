using AvansDevops.DevOps.Analysis;

namespace AvansDevops.Test.DevOps.Analysis;

[TestFixture]
public class SonarqubeActivityTests
{
    [Test]
    public void AnalyzeShouldReturnTrue()
    {
        // Arrange
        var activity = new SonarqubeActivity();

        // Act
        var result = activity.Analyze();

        // Assert
        Assert.That(result, Is.True);
    }
}