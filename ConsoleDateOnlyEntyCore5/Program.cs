#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DateOnlyEFCore.Classes;
using DateOnlyEFCore.Data;
using DateOnlyEFCore.LanguageExtensions;
using DateOnlyEFCore.Models;

namespace DateOnlyEFCore
{
    class Program
    {
        /// <summary>
        /// Displays Age and <see cref="DateOnly"/> for Birth date acquired from EF Core 5
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {


            using var context = new Context();

            var birthdaysList = context.Birthdays.ToList();

            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine(birthdaysList[index]);
            }

        }


    }
}
