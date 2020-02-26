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

    public  class Ex1_2: IExercise
    {
        public Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            var file = "./Tests/text.txt";
            foreach (var (number, lineContent) in HelperCtCI.GetFileLines(file))
            {
                var data = lineContent.Split("%");
                var str1 = data[0];
                var str2 = data[1];
                var val = bool.Parse(data[2]);
                if (IsPermutationSolution1(str1, str2) == val)
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
        private  bool IsPermutationSolution1(string str1, string str2)
        {
            var str1Processed = str1.ToLower().Replace(" ", String.Empty);
            var str2Processed = str2.ToLower().Replace(" ", String.Empty);
            if (string.Compare(str1Processed, str2Processed) == 0)
            {
                return true;
            }
            var str1Ordered = string.Concat(str1Processed.OrderBy(c => c));
            var str2Ordered = string.Concat(str2Processed.OrderBy(c => c));
            return String.Compare(str1Ordered, str2Ordered) == 0;
        }

        private bool IsPermutationSolution2(string str1, string str2)
        {
            var str1Processed = str1.ToLower().Replace(" ", String.Empty);
            var str2Processed = str2.ToLower().Replace(" ", String.Empty);
            if( string.Compare(str1Processed,str2Processed) == 0)
            {
                return true;
            }
            var haveSameLength = str2Processed.Length == str1Processed.Length;
            var containsEqualsChars = !str1Processed.Any(a => !str2Processed.Contains(a));
            return haveSameLength && containsEqualsChars;
        }


      
    }
}