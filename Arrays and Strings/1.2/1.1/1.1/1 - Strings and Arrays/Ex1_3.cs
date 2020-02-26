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
    public class Ex1_3 : IExercise
    {
        public void Run()
        {
            var file = "./Tests/text1_3.txt";
            foreach (var (number, lineContent) in HelperCtCI.GetFileLines(file))
            {
                var data = lineContent.Split(":");
                var inStr = data[0].ToCharArray();
                var outStr = data[1].ToCharArray();
                urlfySolution1(ref inStr);

                if (outStr.Equals(inStr))
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

        private void urlfySolution1(ref char[] str1)
        {
            try
            {
                var str1Length = str1.Length;
                var strCopy = new string(str1);
                var strSplited = strCopy.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var urlfiedCharArray = string.Join("%20", strSplited).ToCharArray();
                Array.Copy(urlfiedCharArray, str1, str1Length);
                Console.WriteLine(str1);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}