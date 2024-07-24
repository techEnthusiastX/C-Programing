using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace extensionmethod
{
       static class StringExtensions
    {
        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello, World!";
            string reversed = text.Reverse();
            Console.WriteLine(reversed);

            Console.ReadLine();
        }
    }

}
