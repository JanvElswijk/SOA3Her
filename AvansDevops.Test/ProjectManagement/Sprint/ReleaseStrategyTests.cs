using NUnit.Framework;
using AvansDevops.ProjectManagement;
using AvansDevops.DevOps;
using Moq;

[TestFixture]
public class ReleaseStrategyTests
{

    
[Test]
public void Execute_WithNullPipeline_ReturnsNull()
{
    using var sw = new StringWriter();
    Console.SetOut(sw); 

    var strategy = new ReviewStrategy();
    var result = strategy.Execute(null, "summary");

    Assert.That(result, Is.Null);

    // (optioneel) Console output terugzetten naar standaard
    Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
}

}