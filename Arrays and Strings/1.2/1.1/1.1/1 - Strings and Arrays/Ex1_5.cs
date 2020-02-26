/*
CiCI - 2015
1 - Arrays and strings
1.5 - There are three types of edits that can be performed on strings: insert a character,
remove a character, or replace a character. Given two strings, write a function to check if they are
one edit (or zero edits) away.
pale, ple -> true
pales, pale -> true
pale, bale -> true
pale, bake -> false
 
 */

using CtCIHelper;
using CtDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CtDI {
	public class Ex1_5 : IExercise {
		public void Run() {
			var file = "./Tests/text1_5.txt";
			foreach (var (number, lineContent) in HelperCtCI.GetFileLines(file)) {
				var data = lineContent.Split("%");
				var str1 = data[0];
				var str2 = data[1];
				var value = bool.Parse(data[2]);

				if (isOneOrLessOp(str1, str2) == value) {
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

		private bool isOneOrLessOp(string str1, string str2) {

			if (str1 == str2) { return true; }

			if (str2.Length == str1.Length) {
				var sum = 0;
				for (int i = 0; i < str1.Length; i++) {
					sum += (str1.ElementAt(i) - str2.ElementAt(i)) != 0 ? 1 : 0;
				}
				return sum <= 1;
			}

			if (str1.Length != str2.Length) {
				var diff = str1.Except(str2).ToArray();
				return diff.Count() <= 1;
			}
			return false;
		}

	}
}