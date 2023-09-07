namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();

            Console.WriteLine(stackOfStrings.IsEmpty());

            Stack<string> rangeStack = new Stack<string>();
            rangeStack.Push("One");
            rangeStack.Push("Two");
            rangeStack.Push("Three");

            stackOfStrings.AddRange(rangeStack);

            Console.WriteLine(stackOfStrings.IsEmpty());

            if (!stackOfStrings.IsEmpty())
            {
                foreach (string element in rangeStack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
