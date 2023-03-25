namespace RPGAdventure
{
    internal class GUI
    {
        public static void Title(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            title = $"-----{title}-----\n\n";
            Console.WriteLine(title);
            Console.ResetColor();
        }
        public static void Menu(string num, string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            text = $"{num} : {text}\n";
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static string ProgressBar(int min, int max, int width)
        {
            string bar = "{";
            double percent = (double)min / max;
            int complete = Convert.ToInt32(percent * width);
            int incomplete = width - complete;

            for (int i = 0; i < complete; i++)
            {
                bar += "=";
            }
            for (int i = complete; i < width; i++)
            {
                bar += "-";
            }
            bar += "}";

            return bar;
        }
        public static void SystemNoti(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            text = $"\t ~ {text}! ~\n";
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void GetCommand(string input)
        {
            input = $"- {input}:";
            Console.WriteLine(input);
        }
        public static string GetCommandCount(string input)
        {
            string result = "None";

            while (result == "None")
            {
                try
                {
                    GetCommand(input);
                    result = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    result = "None";
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public static int GetCommandInt(int input)
        {
            int result = 0;
            while (result == 0)
            {
                try
                {
                    result = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    result = 0;
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public static void Slowprint(string text)
        {
            string[] words = text.Split(' ');
            Task t = Task.Run(() =>
            {
                foreach (string word in words)
                {
                    foreach (char letter in word)
                    {
                        Console.Write(letter);
                        Thread.Sleep(100);
                    }

                    Console.Write(" ");
                    Thread.Sleep(250);
                }
            });
            t.Wait();
            Console.WriteLine("\n");
        }
        public static void Congrat(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            text = $"\t ~ {text}! ~\n";
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WaitEnter()
        {
            Console.WriteLine("\nEnter to continue...");
            Console.ReadKey();
        }
    }
}
