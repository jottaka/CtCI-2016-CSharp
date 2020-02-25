using System;
using System.Collections.Generic;
using System.IO;

namespace CtCIHelper
{
    public static class HelperCtCI
    {
        private static List<int> _errorList = new List<int>();
        private static int _successCount = 0;



        public static void PrintResult()
        {
            printSuccess();
            printErros();
        }

        public static void PrintResultAndPause()
        {
            PrintResult();
            Console.ReadKey();
        }

        public static void AddSuccess()
        {
            _successCount++;
        }


        public static void AddErrorLine(int line)
        {
            _errorList.Add(line);
        }

        public static IEnumerable<(int, string)> GetFileLines(string file)
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader(file))
            {
                var line = 0;
                while (!sr.EndOfStream)
                {
                    yield return (++line, sr.ReadLine());
                }
            }
        }

        #region PRIVATE
        private static void printErros()
        {
            if (_errorList.Count > 0)
            {
                var errorLinse = string.Join(',', _errorList);
                Console.WriteLine($"Result does not match on the lines :{errorLinse} ");
            }
        }

        private static void printSuccess()
        {
            if (_errorList.Count == 0)
            {
                Console.WriteLine($"Successful passed in ALL {_successCount} tests!");
            }
            else
            {
                Console.WriteLine($"Success paased in {_successCount} tests!");
            }
        }
        #endregion

    }
}
