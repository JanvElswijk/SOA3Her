using AvansDevops.DevOps.Build;

namespace AvansDevops.Test.DevOps.Build;

[TestFixture]
public class AntAcivityTests
{
    [Test]
    public void BuildShouldReturnTrue()
    {
        // Arrange
        var activity = new AntActivity();

        // Act
        var result = activity.Build();

        // Assert
        Assert.That(result, Is.True);
    }
}