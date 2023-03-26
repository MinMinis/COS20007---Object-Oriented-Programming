namespace RPGAdventure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GamePlay game = new GamePlay();
            GUI.Title("Welcome to RPG Adventure");
            game.Run();
        }
    }
}