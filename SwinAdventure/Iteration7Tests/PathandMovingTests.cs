using SwinAdventure;

namespace Iteration7Tests
{
    [TestFixture]
    public class PathTests
    {
        [TestFixture]
        public class PathTest
        {
            private Command command;
            private Paths _path1;
            private Paths _path2;
            private Locations _location1;
            private Locations _location2;
            private Player _player;

            [SetUp]
            public void SetUp()
            {
                command = new MoveCommand();
                _path1 = new(new string[] { "path1" }, "Path 1", "This is path 1.");
                _path2 = new(new string[] { "path2" }, "Path 2", "This is path 2.");
                _location1 = new(new string[] { "location1" }, "Location 1", "This is location 1.");
                _location2 = new(new string[] { "location2" }, "Location 2", "This is location 2.");
                _player = new Player("Player", "A player");
                // create destination
                _path1.Destination = _location1;
                _path2.Destination = _location2;
                //create direction
                _path1.Direction = "south";
                _path2.Direction = "north";
                //add path
                _location1.AddPath(_path2);
                _location2.AddPath(_path2);
                //_path2.IsLocked = true;
                _player.Location = _location1;
            }

            [Test]
            public void TestMoveToPath()
            {
                _path1.Destination = _location2;
                _path1.Move(_player);
                Assert.That(_player.Location, Is.EqualTo(_location2));
            }

            [Test]
            public void TestGetPathFromLocation()
            {
                Paths path = _location2.GetPath("north");
                Assert.That(path, Is.EqualTo(_path2));
            }

            [Test]
            public void TestPlayerCanLeaveLocationWithValidPath()
            {
                string result = command.Execute(_player, new string[] { "go", "north" });
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo("You have moved north."));
                    Assert.That(_player.Location, Is.EqualTo(_location2));
                });
            }

            [Test]
            public void TestPlayerCantLeaveLocationWithInvalidPath()
            {
                string result = command.Execute(_player, new string[] { "go", "east" });
                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo("You can't go that way."));
                    Assert.That(_player.Location, Is.EqualTo(_location1));
                });
            }
        }
    }
}