using SwinAdventure;

namespace Iteration2Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Item _item;
        private Inventory _inventory;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _item = new(new string[] { "sword", "bronze" }, "bronze sword", "can hit everyone");
            //_inventory = new(new string[] { "inventory" }, "inventory", "a player's inventory");
            _inventory = new Inventory();
            _player = new Player("Thanh Minh", "Hunter");
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_player.AreYou("me"), Is.True);
                Assert.That(_item.AreYou("sword"), Is.True);
            });
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            _player.Inventory.Put(_item);
            Assert.That(_player.Locate(_item.FirstId), Is.EqualTo(_item));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(_player, Is.EqualTo(_player.Locate("me")));
            Assert.That(_player, Is.EqualTo(_player.Locate("inventory")));
        }
        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.That(_player.Locate("School"), Is.EqualTo(null));
        }
        [Test]
        public void TestPlayerFullDescription()
        {
            _player.Inventory.Put(_item);
            string actual = _player.FullDescription;
            string expected = "You are Thanh Minh, Thanh Minh (me).You are carrying: \tbronze sword (sword)";
            Assert.That(expected, Is.EqualTo(actual));
        }
}
}