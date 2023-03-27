namespace RPGAdventure
{
    public class GUI
    {
        public static void Title(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"-----{title}-----\n");
            Console.ResetColor();
        }

        public static void Menu(string num, string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{num} : {text}\n");
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
            Console.WriteLine($"\t ~ {text}! ~\n");
            Console.ResetColor();
        }

        public static void GetCommand(string input)
        {
            Console.WriteLine($"- {input}:");
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
            Console.WriteLine($"\t ~ {text}! ~\n");
            Console.ResetColor();
        }

        public static void WaitEnter()
        {
            Console.WriteLine("\nEnter to continue...");
            Console.ReadKey();
        }
    }
}
