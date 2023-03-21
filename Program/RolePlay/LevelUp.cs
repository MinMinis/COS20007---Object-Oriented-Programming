namespace RolePlay
{
    public class LevelUp
    {
        static Random random = new Random();
        public static string Lv(int x)
        {
            if (x > 10)
            {
                Levelup(x);
                return "\nLevel Up ...\n";
            }
            int remain = 10 - x;
            return $"\nYou need {remain} EXP to level up!";
        }
        public static void Levelup(int i)
        {
            Program.player.Exp -= 10;
            Program.player.Level += 1;
            Program.player.Health = 50; // restore to 50
            Program.player.Health += (Program.player.Level - 1) * random.Next(10, 50);
            Program.player.Damage += random.Next(5, 10);
        }
    }
}
