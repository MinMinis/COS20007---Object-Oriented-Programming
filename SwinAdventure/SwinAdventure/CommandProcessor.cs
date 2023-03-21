namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>
            {
                new LookCommand(),
                new MoveCommand()
                // can be opperate more at here in the future for take command ....
            };
        }
        public string ExecuteCommand(Player player, string[] text)
        {
            string input = text[0].ToLower();
            Command commandToExecute = null;
            // loop to find the most suitable command
            foreach (Command command in _commands)
            {
                if (command.AreYou(input))
                {
                    commandToExecute = command;
                    break;
                }
            }
            // if can't find the suitable command
            if (commandToExecute == null)
            {
                return "I don't know how to " + input + ".";
            }
            return commandToExecute.Execute(player, text);
        }
    }
}
