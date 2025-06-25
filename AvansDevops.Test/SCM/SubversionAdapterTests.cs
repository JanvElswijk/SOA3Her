using NUnit.Framework;
using System;
using System.IO;


    [TestFixture]
    public class SubversionAdapterTests
    {
        [Test]
        public void Commit_WritesToConsole()
        {
            var adapter = new SubversionAdapter();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                adapter.Commit("Test commit");
                var output = sw.ToString();
                Assert.That(output.Contains("Committing changes with message: Test commit"));
            }
        }

        [Test]
        public void Push_WritesToConsole()
        {
            var adapter = new SubversionAdapter();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                adapter.Push();
                var output = sw.ToString();
                Assert.That(output.Contains("Pushing changes to the remote Subversion repository"));
            }
        }

        [Test]
        public void Pull_WritesToConsole()
        {
            var adapter = new SubversionAdapter();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                adapter.Pull();
                var output = sw.ToString();
                Assert.That(output.Contains("Pulling changes"));
            }
        }
        [Test]
        public void CreateBranch_WritesToConsole()
        {
            var adapter = new SubversionAdapter();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                adapter.CreateBranch("feature/new-feature");
                var output = sw.ToString();
                Assert.That(output.Contains("Creating new branch: feature/new-feature"));
            }
        }
    }