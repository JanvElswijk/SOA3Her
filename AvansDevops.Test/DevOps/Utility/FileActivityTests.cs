using System.Reflection;
using AvansDevops.DevOps.Utility;

namespace AvansDevops.Test.DevOps.Utility;

[TestFixture]
public class FileActivityTests
{
    [Test]
    public void RunUtilityWithCopyShouldReturnTrue()
    {
        // Arrange
        var activity = new FileActivity("./test.bat", "./copy-test.bat");

        // Act
        var result = activity.RunUtility();

        // Assert
        Assert.That(result, Is.True);
    }    
    [Test]
    public void RunUtilityWithDeleteShouldReturnTrue()
    {
        // Arrange
        var activity = new FileActivity("./copy-test.bat");

        // Act
        var result = activity.RunUtility();

        // Assert
        Assert.That(result, Is.True);
    }    
    [Test]
    public void RunUtilityWithDownloadShouldReturnTrue()
    {
        // Arrange
        var activity = new FileActivity(new Uri("https://example.com/test.bat"));

        // Act
        var result = activity.RunUtility();

        // Assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void RunUtilityWithInvalidOperationShouldReturnFalse()
    {
        // Arrange
        var activity = new FileActivity("./test.bat", "./copy-test.bat");
        var enumType = typeof(FileActivity).GetNestedType("FileOperation", BindingFlags.NonPublic);
        var field = typeof(FileActivity).GetField("_operation", BindingFlags.NonPublic | BindingFlags.Instance);
        var invalidValue = Enum.ToObject(enumType, 999);
        field.SetValue(activity, invalidValue);

        // Act
        var result = activity.RunUtility();

        // Assert
        Assert.That(result, Is.False);
    }
}