namespace PlayCatch
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                try
                {
                    string[] cmdArgs = Console.ReadLine().Split(' ');
                    string cmd = cmdArgs[0];
                    int index = int.Parse(cmdArgs[1]);

                    if (cmd == "Show")
                    {
                        Console.WriteLine(numbers[index]);
                    }

                    else
                    {
                        int commonArg = int.Parse(cmdArgs[2]);

                        if (index < 0 || index >= numbers.Length)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        if (cmd == "Replace")
                        {
                            numbers[index] = commonArg;
                        }
                        else if (cmd == "Print")
                        {
                            if (commonArg >= numbers.Length)
                            {
                                throw new IndexOutOfRangeException();
                            }

                            Console.WriteLine(String.Join(", ", numbers.Select(n => n.ToString()).ToArray(), index, commonArg - index + 1));
                        }
                    }
                }
                catch (FormatException)
                {
                    exceptionsCount++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionsCount++;
                    Console.WriteLine("The index does not exist!");
                }
            }

            Console.WriteLine(String.Join(", ", numbers.Select(n => n.ToString()).ToArray()));
        }
    }
}
