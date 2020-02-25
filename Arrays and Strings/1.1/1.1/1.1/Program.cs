/*
CiCI - 2015
1 - Arrays and strings
1.1 - Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
cannot use additional data structures? 

*/

using CtCIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{

    public static class OnlyUniqueCharsTester
    {

        public static bool HasUniqueOnlyCharsWithHashSet(string input)
        {
            var hashSet = new HashSet<char>();
            foreach (var c in input.ToLower().Replace(" ",String.Empty))
            {
                if (hashSet.Contains(c)) { return false; }
                hashSet.Add(c);
            }
            return true;
        }

        public static bool HasOnlyUniqueChars(string input)
        {
            var inputWithoutSpace = input.Replace(" ", String.Empty);
            return inputWithoutSpace.Replace(" ", String.Empty).ToLower().Distinct().Count() == inputWithoutSpace.Length;
        }


    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var file = "./text.txt";
            foreach(var (number, lineContent) in HelperCtCI.GetFileLines(file))
            {
                var data = lineContent.Split("%");
                var str = data[0];
                var val = bool.Parse(data[1]);
                if (OnlyUniqueCharsTester.HasOnlyUniqueChars(str) == val)
                {
                    HelperCtCI.AddSuccess();
                }
                else
                {
                    HelperCtCI.AddErrorLine(number);
                }
            }

            HelperCtCI.PrintResultAndPause();
        }
    }
}