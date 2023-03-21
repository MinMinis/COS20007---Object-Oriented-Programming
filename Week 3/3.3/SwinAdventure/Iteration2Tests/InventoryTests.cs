using SwinAdventure;

namespace Iteration2Tests
{
    [TestFixture]
    public class InventoryTests
    {
        private Item _item;
        private Inventory _inventory;

        [SetUp]
        public void Setup()
        {
            _item = new (new String[] { "sword" }, "bronze sword", "can hit everyone");
            //_inventory = new (new string[] { "inventory" }, "inventory", "a player's inventory");
            _inventory = new Inventory();
        }

        [Test]
        public void TestFindItem()
        {
            _inventory.Put(_item);
            Assert.That(_inventory.HasItem(_item.FirstId), Is.True);
        }
        [Test]
        public void TestNoItemFind()
        {
            Assert.That(_inventory.HasItem("knife"), Is.False);
        }

        [Test]
        public void TestFetchItem()
        {
            _inventory.Put(_item);
            Assert.That(_inventory.Fetch(_item.FirstId), Is.EqualTo(_item));
        }
        [Test]
        public void TestTakeItem()
        {
            _inventory.Put(_item);
            _inventory.Take(_item.FirstId);
            Assert.That(_inventory.HasItem(_item.FirstId), Is.False);
        }
        [Test]
        public void TestItemList()
        {
            _inventory.Put(_item);
            Assert.That(_inventory.ItemList, Is.EqualTo("\tbronze sword (sword)"));
        }
    }
}