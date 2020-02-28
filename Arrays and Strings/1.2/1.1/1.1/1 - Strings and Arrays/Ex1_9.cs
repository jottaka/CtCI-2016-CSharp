/*
CiCI - 2015
1 - Arrays and strings
1.9 - Assumeyou have a method isSubstringwhich checks if one word is a substring
of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").
*/

using CtCIHelper;
using CtDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtDI {
	public class Ex1_9 : IExercise {
		public void Run() {
			var file = "./Tests/text1_9.txt";
			foreach (var (number, lineContent) in HelperCtCI.GetFileLines(file)) {
				var data = lineContent.Split("%");
				var inStr = data[0];
				var outStr = data[1];
				var value = bool.Parse(data[2]) ;

				if (isRotation(inStr, outStr) == value) {
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

		public bool isRotation(string str1, string str2) {
			if(str1.Length != str2.Length) { return false; }

			var concatStr2 = string.Concat(str2, str2);
			return concatStr2.Contains(str1);
		}
	}
}