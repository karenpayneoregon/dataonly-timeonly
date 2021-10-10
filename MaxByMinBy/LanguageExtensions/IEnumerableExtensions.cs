using System;
using System.Collections.Generic;
using System.Linq;
using MaxByMinBy.Classes;
using MaxByMinBy.Models;
using Age = MaxByMinBy.Classes.Age;

namespace MaxByMinBy.LanguageExtensions
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Wrapper for MaxBy/MinBy else we would raise
        ///  At least one object must implement <see cref="IComparable"/>
        /// </summary>
        /// <param name="sender">Person list</param>
        /// <returns>IEnumerable&lt;Age&gt;</returns>
        public static IEnumerable<Age> Ages(this List<Person> sender) => 
            sender.Select(person => person.BirthDateAsDateTime.Age(DateTime.Now));
    }
}
