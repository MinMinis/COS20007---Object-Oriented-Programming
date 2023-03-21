using SwinAdventure;

namespace Iteration3
{
    [TestFixture]
    public class LookCommandTests
    {
        private Command command;
        private Player player;
        private Item gem;
        private Bags bag;
        private Inventory inventory;
        [SetUp]
        public void Setup()
        {
            command = new LookCommand();
            player = new("Minh", "Hunter");
            gem = new(new string[] {"gem", "diamond"}, "big gem", "a valuable item");
            bag = new(new string[] {"bag", "cloth"}, "big bag", "can contain everything");
            inventory = new();
        }

        [Test]
        public void TestLookAtMe()
        {
            // there is nothing in the inventory yet so there is nothing to display
            string expected = "You are Minh, Minh (me).You are carrying: ";
            string actual = command.Execute(player, new string[] { "look", "at", "inventory" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtGem()
        {
            // player put gem in inventory
            player.Inventory.Put(gem);
            string actual = command.Execute(player, new string[] { "look","at","gem"});
            Assert.That(actual, Is.EqualTo(gem.FullDescription));
        }
        [Test]
        public void TestLookAtUnk()
        {
            string actual = command.Execute(player, new string[] { "look", "at", "gem" });
            Assert.That(actual, Is.EqualTo("I can't find the gem"));
        }
        [Test]
        public void TestLookAtGemInMe()
        {
            //Look at gem in inventory
            player.Inventory.Put(gem);
            string actual = command.Execute(player, new string[] { "look", "at", "gem" , "in", "inventory"});
            Assert.That(actual, Is.EqualTo(gem.FullDescription));
        }
        [Test]
        public void TestLookAtGemInBag()
        {
            // put gem in bag then put bag in player's inventory
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);
            string actual = command.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(actual, Is.EqualTo(gem.FullDescription));
        }
        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);
            string actual = command.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(actual, Is.EqualTo("I can't find the bag"));
        }
        [Test]
        public void TestLookAtNoGemInBag()
        {
            player.Inventory.Put(bag);
            string actual = command.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(actual, Is.EqualTo("I can't find the gem"));
        }
        [Test]
        public void TestInvalidLook()
        {
            string actual = command.Execute(player, new string[] { "look", "around"});
            Assert.That(actual, Is.EqualTo("I don't know how to look like that"));

            string expected = command.Execute(player, new string[] { "hello"});
            Assert.That(expected, Is.EqualTo("I don't know how to look like that"));

            string command1 = command.Execute(player, new string[] { "look", "at", "a", "at", "b" });
            Assert.That(command1, Is.EqualTo("What do you want to look in"));

            string command2 = command.Execute(player, new string[] { "look", "at", "a"});
            Assert.That(command2, Is.EqualTo("I can't find the a"));

            string command3 = command.Execute(player, new string[] { "hello", "at", "a" });
            Assert.That(command3, Is.EqualTo("Error in look input"));

            string command4 = command.Execute(player, new string[] { "look", "by", "a" });
            Assert.That(command4, Is.EqualTo("Error in look input"));
        }
    }
}