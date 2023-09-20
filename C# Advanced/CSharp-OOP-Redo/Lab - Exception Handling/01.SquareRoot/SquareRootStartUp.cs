namespace SquareRoot
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
