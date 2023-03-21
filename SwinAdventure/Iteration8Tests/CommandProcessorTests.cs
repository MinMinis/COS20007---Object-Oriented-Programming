using SwinAdventure;
using System.Numerics;

namespace Iteration8Tests
{
    [TestFixture]
    public class CommandProcessorTests
    {
        private CommandProcessor command;
        private Paths _path1;
        private Paths _path2;
        private Locations _location1;
        private Locations _location2;
        private Player _player;
        private Item gem;


        [SetUp]
        public void Setup()
        {
            command = new();
            gem = new(new string[] { "gem", "diamond" }, "big gem", "a valuable item");
            _path1 = new(new string[] { "path1" }, "Path 1", "This is path 1.");
            _path2 = new(new string[] { "path2" }, "Path 2", "This is path 2.");
            _location1 = new(new string[] { "location1" }, "Location 1", "This is location 1.");
            _location2 = new(new string[] { "location2" }, "Location 2", "This is location 2.");
            _player = new Player("Minh", "Minh");
            // create destination
            _path1.Destination = _location1;
            _path2.Destination = _location2;
            //create direction
            _path1.Direction = "south";
            _path2.Direction = "north";
            //add path
            _location1.AddPath(_path2);
            _location2.AddPath(_path2);

            _player.Location = _location1;


        }

        [Test]
        public void TestLookAtNone()
        {
            string expected = "I can't find the none";
            string actual = command.ExecuteCommand(_player, new string[] { "look", "at", "none" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtInventory()
        {
            string expected = "You are Minh, Minh (me).You are carrying: ";
            string actual = command.ExecuteCommand(_player, new string[] { "look", "at", "inventory" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestLookAtGem()
        {
            _player.Inventory.Put(gem);
            string actual = command.ExecuteCommand(_player, new string[] { "look", "at", "gem" });
            Assert.That(actual, Is.EqualTo(gem.FullDescription));
        }
        [Test]
        public void TestNoTeach()
        {
            string expected = "I don't know how to teach.";
            string actual = command.ExecuteCommand(_player, new string[] { "teach" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestCantMove()
        {
            string expected = "You can't go that way.";
            string actual = command.ExecuteCommand(_player, new string[] { "move", "s" });
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void TestCanMoveToLocation()
        {
            string expected = "You have moved north.";
            string actual = command.ExecuteCommand(_player, new string[] { "move", "n" });
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}