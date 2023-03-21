using SwinAdventure;

namespace Iteration3
{
    [TestFixture]
    public class BagTests
    {
        private Bags _bag1, _bag2;
        private Item _item1, _item2;
        [SetUp]
        public void Setup()
        {
            _bag1 = new Bags(new string[] { "bag", "cloth" }, "big bag", "A bag can contain everything");
            _bag2 = new Bags(new string[] { "bag2", "feather" }, "small bag", "A bag can contain small items");
            _item1 = new Item(new string[] { "sword", "bronze"}, "bronze sword", "Short range attack");
            _item2 = new Item(new string[] { "gun", "iron" }, "iron sword", "Long range attack");
        }

        [Test]
        public void TestLocatesItems()
        {
            _bag1.Inventory.Put(_item1);
            Assert.That(_bag1.Locate(_item1.FirstId), Is.EqualTo(_item1));
        }
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(_bag1.Locate("bag"), Is.EqualTo(_bag1));
        }
        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(_bag1.Locate("Money"), Is.EqualTo(null));
        }
        [Test]
        public void TestFullDescription()
        {
            _bag1.Inventory.Put(_item1);
            Assert.That(_bag1.FullDescription, Is.EqualTo("In the big bag, you can see \n\tbronze sword (sword)"));
        }
        [Test]
        public void TestBagInBag()
        {
            _bag1.Inventory.Put(_bag2);
            Assert.That(_bag1.Locate("bag2"), Is.EqualTo(_bag2));
            _bag1.Inventory.Put(_item1);
            Assert.That(_bag1.Locate(_item1.FirstId), Is.EqualTo(_item1));
            _bag2.Inventory.Put(_item2);
            Assert.That(_bag1.Locate(_item2.FirstId), Is.EqualTo(null));
        }

    }
}