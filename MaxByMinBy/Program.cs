using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using MaxByMinBy.Classes;
using MaxByMinBy.LanguageExtensions;
using MaxByMinBy.Models;

namespace MaxByMinBy
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(new string('_',20));
            MinByAge();
            Debug.WriteLine(new string('_',20));
            MaxByAge();
            Debug.WriteLine(new string('_',20));
            MaxByAgeWithIComparer();
            Debug.WriteLine(new string('_',20));
        }

        /// <summary>
        /// Using <see cref="Enumerable.MaxBy"/> get minimum age
        /// from <see cref="DateHelperExtensions.Age"/> extension
        /// against <see cref="Person.BirthDate"/> transformed
        /// to a DateTime?
        /// </summary>
        /// <remarks>
        /// There is an overload that accepts IComparer
        /// </remarks>
        static void MaxByAge()
        {
            Debug.WriteLine($"Running {nameof(MaxByAge)}");

            List<Person> people = Operations.ReadPeople();

            var ageMaximum = people.Ages().MaxBy(age => age.Years);

            Debug.WriteLine($"MaxBy: {ageMaximum!.Years}");

        }
        static void MaxByAgeWithIComparer()
        {
            Debug.WriteLine($"Running {nameof(MaxByAgeWithIComparer)}");

            List<Person> people = Operations.ReadPeople();
            List<Human> humans = people.Select(x => new Human() {FirstName = x.FirstName, LastName = x.LastName, BirthDate = x.BirthDateAsDateTime}).ToList();

            var ageMaximum = humans.MaxBy(age => age.BirthDate.Age(DateTime.Now).Years);
            Debug.WriteLine($"MaxBy IComparer: {ageMaximum.BirthDate.Age(DateTime.Now).Years}");

        }
        /// <summary>
        /// Using <see cref="Enumerable.MinBy"/> get minimum age
        /// from <see cref="DateHelperExtensions.Age"/> extension
        /// against <see cref="Person.BirthDate"/> transformed
        /// to a DateTime?
        /// </summary>
        /// <remarks>
        /// There is an overload that accepts IComparer
        /// </remarks>
        static void MinByAge()
        {
            Debug.WriteLine($"Running {nameof(MinByAge)}");

            List<Person> people = Operations.ReadPeople();

            var ageMinimum = people.Ages().MinBy(age => age.Years);

            Debug.WriteLine($"MinBy: {ageMinimum!.Years}");

        }
    }
}
