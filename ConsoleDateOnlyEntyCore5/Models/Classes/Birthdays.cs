using System;
using DateOnlyEFCore.Classes;
using HelperLibrary.LanguageExtensions;

// ReSharper disable once CheckNamespace

namespace DateOnlyEFCore.Models
{
    public partial class Birthdays
    {
        public string Age => BirthDate?.Age(DateTime.Now).YearsMonthsDays;

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString() 
            => $"{Id,-4:D2}{FirstName,-12}{LastName,-12}{BirthDateOnly:MM/dd/yyyy}{new string(' ', 5)}{Age}";
    }
}
