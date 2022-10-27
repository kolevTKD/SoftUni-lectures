using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings customStack = new StackOfStrings();
            Console.WriteLine(customStack.IsEmpty());

            customStack.Push("1");
            customStack.Push("2");
            customStack.Push("3");
            customStack.Push("4");
            customStack.Push("5");

            Console.WriteLine(customStack.IsEmpty());

            Stack<string> testStack = new Stack<string>();
            testStack.Push("6");
            testStack.Push("7");
            testStack.Push("8");
            testStack.Push("9");
            testStack.Push("10");

            customStack.AddRange(testStack);

            while (customStack.Count != 0)
            {
                Console.WriteLine(customStack.Pop());
            }
        }
    }
}
