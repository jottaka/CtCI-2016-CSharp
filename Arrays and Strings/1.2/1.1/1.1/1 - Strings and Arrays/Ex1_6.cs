/*
CiCI - 2015
1 - Arrays and strings
1.6 - Implement a method to perform basic string compression using the counts
of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
"compressed" string would not become smaller than the original string, your method should return
the original string. You can assume the string has only uppercase and lowercase letters (a - z).

obs:can be improved adding a verification to count consecutive chars before building the out string
*/

using CtCIHelper;
using CtDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtDI {
	public class Ex1_6 : IExercise {
		public void Run() {
			var file = "./Tests/text1_6.txt";
			foreach (var (number, lineContent) in HelperCtCI.GetFileLines(file)) {
				var data = lineContent.Split("%");
				var inStr = data[0];
				var outStr = data[1];


				if (getCompactedStr(inStr) == outStr) {
					HelperCtCI.AddSuccess();
				} else {
					HelperCtCI.AddErrorLine(number);
				}
			}

			HelperCtCI.PrintResultAndPause();
		}

		public Task RunAsync() {
			throw new NotImplementedException();
		}

		private string getCompactedStr(string inStr) {

			var outStr = new StringBuilder();
			var count = 1;
			for (var i = 0; i < inStr.Length ; i++) {
				if (i == inStr.Length-1 || inStr.ElementAt(i) != inStr.ElementAt(i + 1)  ) {
					outStr.Append($"{inStr.ElementAt(i)}{count}");
					count = 1;
				} else {
					count++;
				}
			}
			var compactedStr = outStr.ToString();
			return compactedStr.Length > inStr.Length ? inStr : compactedStr;
		}


	}
}