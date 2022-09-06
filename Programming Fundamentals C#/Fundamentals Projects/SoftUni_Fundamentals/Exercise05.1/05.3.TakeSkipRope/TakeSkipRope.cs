using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._3.TakeSkipRope
{
    internal class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string encryptedMsg = Console.ReadLine();
            List<int> tempNums = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            List<char> nonNums = new List<char>();
            StringBuilder message = new StringBuilder();

            for (int index = 0; index < encryptedMsg.Length; index++)
            {
                if (char.IsDigit(encryptedMsg[index]))
                {
                    tempNums.Add((int)char.GetNumericValue(encryptedMsg[index]));
                    continue;
                }

                nonNums.Add(encryptedMsg[index]);
            }

            for (int index = 0; index < tempNums.Count; index++)
            {
                if (index % 2 == 0)
                {
                    takeList.Add(tempNums[index]);
                    continue;
                }

                skipList.Add(tempNums[index]);
            }

            int atIndex = 0;
            for (int index = 0; index < takeList.Count; index++)
            {

                int takeCount = takeList[index];
                int skipCount = skipList[index];

                if (takeCount > nonNums.Count)
                {
                    takeCount = nonNums.Count;
                }

                else if (skipCount > nonNums.Count)
                {
                    skipCount = nonNums.Count;
                }

                for (int take = 0; take < takeCount; take++)
                {

                    message.Append(nonNums[atIndex]);
                    atIndex++;

                    if (atIndex == nonNums.Count)
                    {
                        break;
                    }
                }

                atIndex += skipCount;
            }

            Console.WriteLine(message);
        }
    }
}
