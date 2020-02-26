/*
CiCI - 2015
1 - Arrays and strings
1.4 -  Given a string, write a function to check if it is a permutation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation
is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words. 
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

                if (hasPalindromesOptimized(inStr) == value)
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



        private bool hasPalindromesOptimized(string str)
        {
            var hasPalindrome = false;
            var processedString = str.ToLower().Replace(" ", "");

            // a palindrome must have N even count of equal chars and at maximun a odd count 
            var groupedCharCount = processedString.GroupBy(c => c)
                         .Select(c => new
                         {
                             Char = c.Key,
                             Count = c.Count()
                         });
            var sum = groupedCharCount.Sum(v => (v.Count % 2));
            if (sum > 1) { return false; }

            var stringToPermuteList = groupedCharCount.ToList().ConvertAll(
                s => new String(new char[s.Count / 2]).Replace('\0', s.Char)
                );
            var uniqueChar = groupedCharCount.FirstOrDefault(c => c.Count == 1)?.Char;
            var stringToPermute = string.Concat(stringToPermuteList);
            foreach (var halfPermutation in getPermutationsOptimized(stringToPermute))
            {
                var inverseHalfPermutation = string.Concat(halfPermutation.ToArray().Reverse());
                //var p1 = string.Concat(halfPermutation, $"{uniqueChar}", inverseHalfPermutation);
                var p2 = string.Concat(inverseHalfPermutation, $"{uniqueChar}", halfPermutation);



                //Console.WriteLine($"Palindrome:{p1}");

                Console.WriteLine($"Palindrome:{p2}");
                hasPalindrome = true;
            }
            return hasPalindrome;
        }


        private bool hasPalindromeNaive(string str1)
        {
            var hasPalindrome = false;
            var processedString = str1.ToLower().Replace(" ", "");

            if (isPalindrome(processedString)) { return true; }

            foreach (var permutation in getPermutationsNaive(processedString))
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
            foreach (var permutation in list)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    repetitionSet.Add(permutation.Insert(i, $"{currentChar}"));
                }
            }

            return repetitionSet.ToList();
        }

        private IEnumerable<string> getPermutationsOptimized(string input)
        {
            var repetitionSet = new HashSet<string>();
            var charSet = new HashSet<char>();
            if (input.Length <= 1)
            {
                yield return input;
            }
            else
            {
                var distinctChars = new string(input.Distinct().ToArray());
                var halfIdx = (int)Math.Ceiling(distinctChars.Length / 2.0);
                distinctChars = distinctChars.Remove(halfIdx, distinctChars.Length-halfIdx) ;
                foreach (var dc in distinctChars)
                {
                    var subStr = input.Remove(input.IndexOf(dc),1);
                    foreach (var permutation in getPermutationsOptimized(subStr))
                    {
                        var perm1 = permutation.Insert(0, $"{dc}");
                        var perm2 = string.Concat(perm1.ToArray().Reverse());
                        if (!repetitionSet.Contains(perm1))
                        {
                            repetitionSet.Add(perm1);
                            yield return perm1;
                        }
                        if (!repetitionSet.Contains(perm2))
                        {
                            repetitionSet.Add(perm2);
                            yield return perm2;
                        }
                    }

                }
            }

        }



        private bool isPalindrome(string input)
        {
            return
                string.Compare(string.Concat(input.ToArray().Reverse()), input) == 0;
        }


    }
}