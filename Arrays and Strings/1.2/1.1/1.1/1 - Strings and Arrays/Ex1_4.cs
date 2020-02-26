/*
CiCI - 2015
1 - Arrays and strings
1.2 - Check Permutation: Given two strings, write a method to decide if one is a permutation of the
other. 

*/

using CtCIHelper;
using CtDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CtDI
{
    public class Ex1_4 : IExercise
    {
        public void Run()
        {
            var file = "./Tests/text1_4.txt";
            foreach (var (number, lineContent) in HelperCtCI.GetFileLines(file))
            {
                var data = lineContent.Split("%");
                var inStr = data[0];
                var value = bool.Parse(data[1]);

                if (hasPalindromeNaive(inStr) == value)
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

        public Task RunAsync()
        {
            throw new NotImplementedException();
        }

        private bool hasPalindromeNaive(string str1)
        {
            var hasPalindrome = false;
            var processedString = str1.ToLower().Replace(" ", "");
            if (isPalindrome(processedString)) { return true; }
            
            foreach( var permutation in getPermutationsNaive(processedString))
            {
                //Console.WriteLine(permutation);
                if (isPalindrome(permutation))
                {
                    Console.WriteLine($"Palindrome:{permutation}");
                    hasPalindrome = true;
                }
            }
            return hasPalindrome;
        }

        private List<string> getPermutationsNaive(string input)
        {
            var repetitionSet = new HashSet<string>();
            if (input.Length == 1)
            {
                var initList = new List<string>();
                initList.Add(input);
                return initList;
            }
            var currentChar = input.ElementAt(0);
            var subStr = input.Remove(0, 1);
            var list = getPermutationsNaive(subStr);
            var toReturnList = new List<string>();
            foreach (var permutation in list )
            {
                for (var i = 0; i < input.Length; i++)
                {
                    repetitionSet.Add(permutation.Insert(i, $"{currentChar}"));
                }
            }

            return repetitionSet.ToList();
        }

        private bool isPalindrome(string input)
        {
            return
                string.Compare(string.Concat(input.ToArray().Reverse()), input) == 0;
        }


    }
}