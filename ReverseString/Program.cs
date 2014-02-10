using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "gappu";
            Console.WriteLine("Reverse of {0} is {1}", input1, ReverseSingleStringRecursive(input1));

            string input2 = "To be or not to be";
            Console.WriteLine("Reversed version of {0} is {1}", input2, ReverseWordsIterative2(input2));

        }

        // Reversing a single string recursively
        static string ReverseSingleStringRecursive(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
               return null; 
            }
            else if (s.Length == 1)
            {    
               return s;
            }
            else
            {
               char firstChar = s[0];
               string result = ReverseSingleStringRecursive(s.Substring(1, s.Length - 1));
               return result + firstChar;
            }
        }

        // Reversing a sentence (a set of strings) iteratively - 1
        private static string ReverseWordsIterative1(string input)
        {
            string[] words = input.Split(' ');

            return String.Join(" ", words.Reverse());
        }

        // Reversing a sentence (a set of strings) iteratively - 2
        static string ReverseWordsIterative2(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            ReverseSingleStringIterative(sb, 0, sb.Length - 1);

            // Now make a second pass and reverse each individual string

            int leftIndex = 0;
            int rightIndex = 0;
            int delimiter = ' ';

            for (int i = 0; i <= sb.Length; i++)
            {
                if ((i < sb.Length) && (sb[i] != delimiter))
                {
                    rightIndex++;
                }
                else
                {
                    ReverseSingleStringIterative(sb, leftIndex, rightIndex - 1);
                    leftIndex = i + 1;
                    rightIndex = i + 1;
                }
            }

            return sb.ToString();
        }

        // Reversing a single string iteratively
        static void ReverseSingleStringIterative(StringBuilder input, int leftIndex, int rightIndex)
        {
            // Validate leftIndex and rightIndex
            while (leftIndex < rightIndex)
            {
                char temp = input[leftIndex];
                input[leftIndex] = input[rightIndex];
                input[rightIndex] = temp;

                leftIndex++;
                rightIndex--;
            }
        }
    }
}
