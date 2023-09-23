namespace HighQualityMistakes
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
