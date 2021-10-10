using System;
using System.Collections.Generic;
using System.Linq;
using DateOnlyEFCore.Models;
using HelperLibrary.LanguageExtensions;
using DateHelperExtensions = HelperLibrary.LanguageExtensions.DateHelperExtensions; 

namespace DateOnlyEFCore.LanguageExtensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Wrapper for MaxBy/MinBy
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static IEnumerable<Age> Ages(this List<Person> sender) => 
            sender.Select(person => person.BirthDateAsDateTime.Age(DateTime.Now));
    }
}
