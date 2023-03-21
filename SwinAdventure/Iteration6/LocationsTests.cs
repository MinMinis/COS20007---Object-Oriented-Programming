using NUnit.Framework;
using SwinAdventure;

namespace Iteration6
{
    [TestFixture]
    public class LocationsTests
    {
        private Player player;
        private Item gem;
        private Item sword;
        private Locations location1;
        private Locations location2;
        [SetUp]
        public void Setup()
        {
            player = new("Minh", "Hunter");
            gem = new(new string[] { "gem", "diamond" }, "big gem", "a valuable item");
            sword = new(new string[] { "sword", "iron" }, "short sword", "can damage item");
            location1 = new(new string[] {"jungle", "danger"}, "a dangerous jungle", "hidden items are placed");
            location2 = new(new string[] { "dessert", "dry" }, "dry dessert", "no plants can live");
        }

        [Test]
        public void LocationsIdentifyThemselvesTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(location1.Locate("jungle"), Is.EqualTo(location1));
                Assert.That(location2.Locate("dessert"), Is.EqualTo(location2));
            });
        }

        [Test]
        public void LocationsLocateItemsTheyHaveTest()
        {
            location1.Inventory.Put(gem);
            Assert.That(location1.Locate(gem.FirstId), Is.EqualTo(gem));
            location2.Inventory.Put(sword);
            Assert.That(location2.Locate(sword.FirstId), Is.EqualTo(sword));
        }
        [Test]
        public void PlayersLocateItemsInTheirLocationTest()
        {
            player.Location = location1;
            location1.Inventory.Put(gem);
            Assert.That(player.Locate(gem.FirstId), Is.EqualTo(gem));
        }
        [Test]
        public void TestLocationFullDescription()
        {
            location1.Inventory.Put(sword);
            string expected = "You are in a dangerous jungle\nhidden items are placed\nItem in this place: \tshort sword (sword)";
            Assert.That(location1.FullDescription, Is.EqualTo(expected));
        }
        [Test]
        public void TestLocateIsUnknown()
        {
            Assert.That(location1.Locate("dessert"), Is.Null);
        }
    }
}