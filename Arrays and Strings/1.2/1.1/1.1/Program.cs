/*
CiCI - 2015
1 - Arrays and strings
1.2 - Check Permutation: Given two strings, write a method to decide if one is a permutation of the
other. 

*/

using CtCIHelper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CtDI
{

    public class Program
    {
        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IExercise, Ex1_5>()
                .BuildServiceProvider();
            var exercise = serviceProvider.GetRequiredService<IExercise>();

            exercise.Run();

        }
    }
}