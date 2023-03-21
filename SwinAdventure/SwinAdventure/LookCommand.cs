namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(ids: new string[] { "look" }) { }
        public override string Execute(Player p, string[] text) 
        {
            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0].ToLower() != "look")
                {
                    return "Error in look input";
                }
                if (text[1].ToLower() != "at")
                {
                    return "Error in look input";
                }
                if (text.Length == 5)
                {
                    if (text[3].ToLower() != "in")
                    {
                        return "What do you want to look in";
                    }
                }
                if (text.Length == 3)
                {
                    string itemId = text[2];
                    IHaveInventory container = p;
                    return LookAtIn(itemId, container);
                }
                if (text.Length == 5)
                {
                    IHaveInventory fetchcontainer = FetchContainer(p, text[4]);
                    if (fetchcontainer != null)
                    {
                        return LookAtIn(text[2], fetchcontainer);
                    }
                    else
                    {
                        return $"I can't find the {text[4]}";
                    }
                }
            }
            if (text.Length == 1 && text[0].ToLower() == "look")
            {
                return p.Location.FullDescription;
            }
            string expected = text[0].ToLower();
            if (text.Length == 1 && (expected == "inventory" || expected == "inv"))
            {
                return p.FullDescription;
            }
            return "I don't know how to look like that";
        }
        private static IHaveInventory FetchContainer(Player p, string containerId)
        {
            if (p.AreYou(containerId))
            {
                return p;
            }
            return (IHaveInventory)p.Locate(containerId);
        }
        private static string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            } else
            {
                return $"I can't find the {thingId}";
            }
        }
    }
}