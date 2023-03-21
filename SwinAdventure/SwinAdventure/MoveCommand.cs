namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" }) { }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length < 2)
            {
                return "Move where?";
            }

            string direction = text[1].ToLower();
            switch (direction)
            {
                case "n":
                case "north":
                    direction = "north";
                    break;
                case "s":
                case "south":
                    direction = "south";
                    break;
                case "e":
                case "east":
                    direction = "east";
                    break;
                case "w":
                case "west":
                    direction = "west";
                    break;
                default:
                    return "I don't know how to go that way.";
            }
            Paths path = player.Location.GetPath(direction);
            if (path == null)
            {
                return "You can't go that way.";
            }

            if (path.IsLocked)
            {
                return "The path is locked.";
            }

            player.Location = path.Destination;
            return "You have moved " + direction + ".";
        }
    }
}

