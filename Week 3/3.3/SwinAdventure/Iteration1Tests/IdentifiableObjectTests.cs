using SwinAdventure;

namespace Iteration1Tests
{
    [TestFixture]
    public class Identifiable_ObjectTests
    {
        private IdentifiableObject id;

        [SetUp]
        public void Setup()
        {
            id = new IdentifiableObject(new string[] { "fred", "bob" });
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
            Assert.That(id.AreYou("fred"), id.FirstId);
        }
        [Test]
        public void TestAddID()
        {
            id.AddIdentifier("wilma");
            Assert.That(id.AreYou("wilma"), Is.True);
        }
    }
}