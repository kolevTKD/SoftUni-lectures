namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public StackOfStrings()
        {
            stack = new Stack<string>();
        }

        public bool IsEmpty() =>
            stack.Count > 0 ? false : true;


        public Stack<string> AddRange(Stack<string> range)
        {
            foreach (string item in range)
            {
                stack.Push(item);
            }

            return range;
        }
    }
}
