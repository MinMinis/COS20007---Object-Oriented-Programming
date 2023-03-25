namespace RPGAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamePlay game = new GamePlay();
            GUI.Title("Welcome");
            game.Run();
        }
    }
}