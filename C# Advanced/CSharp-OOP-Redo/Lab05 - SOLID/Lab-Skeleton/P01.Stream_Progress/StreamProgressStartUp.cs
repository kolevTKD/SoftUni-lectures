using System;

namespace P01.Stream_Progress
{
    public class StartUp
    {
        static void Main()
        {
            IStreamable file = new File("File", 100, 1000);
            IStreamable music = new Music("Lepa Brena", "Chep u zema", 200, 1000);

            StreamProgressInfo spt = new StreamProgressInfo(music);
            Console.WriteLine(spt.CalculateCurrentPercent());
        }
    }
}
