using System;

namespace _10_XRageExpenses
{
    class XRageExpenses
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int headset = 0;
            int mouse = 0;
            int keyboard = 0;
            int display = 0;

            for (int currentGame = 1; currentGame <= lostGamesCount; currentGame++)
            {
                if (currentGame % 2 == 0)
                {
                    headset++;
                }

                if (currentGame % 3 == 0)
                {
                    mouse++;
                }

                if (currentGame % 2 == 0 && currentGame % 3 == 0)
                {
                    keyboard++;
                    if (keyboard % 2 == 0)
                    {
                        display++;
                    }
                }
            }
            double totalHeadsets = headsetPrice * headset;
            double totalMouses = mousePrice * mouse;
            double totalKeyboards = keyboardPrice * keyboard;
            double totalDisplays = displayPrice * display;
            double rageExpenses = totalHeadsets + totalMouses + totalKeyboards + totalDisplays;

            Console.WriteLine($"Rage expenses: {rageExpenses:f2} lv.");
        }
    }
}
