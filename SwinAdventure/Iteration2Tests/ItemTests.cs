using SwinAdventure; 

namespace Iteration2Tests
{
    [TestFixture]
    public class ItemTests
    {
        private Item Shovel;

        [SetUp]
        public void Setup()
        {
            Shovel = new(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.That(Shovel.AreYou("shovel"), Is.True);
        }
        [Test]
        public void TestShortDescription()
        {
            Assert.That(Shovel.ShortDescription, Is.EqualTo("a shovel (shovel)"), Shovel.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(Shovel.FullDescription, Is.EqualTo("This is a might fine ..."), Shovel.FullDescription);
        }
    }
}