using Iteration1;
using System.Security.Cryptography;

namespace Iteration1Test
{
    [TestFixture]
    public class Identifiable_ObjectTests
    {
        private Identifiable_Object id;

        [SetUp]
        public void Setup()
        {
            id = new Identifiable_Object(new string[] { "fred", "bob" });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.That(id.AreYou("bob"), Is.True);
        }
        [Test]
        public void TestNotAreYou()
        {
            Assert.That(id.AreYou("wilma"), Is.False);
        }
        [Test]
        public void TestCaseSensitive()
        {
            Assert.That(id.AreYou("FRED"), Is.True);
        }
        [Test]
        public void TestFirstID()
        {
            Assert.That(id.AreYou("fred"), id.FirstId());
        }
        [Test]
        public void TestAddID()
        {
            id.AddIdentifier("wilma");
            Assert.That(id.AreYou("wilma"), Is.True);
        }
    }
}