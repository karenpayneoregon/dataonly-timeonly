using System;
using MaxByMinBy.Classes;

namespace MaxByMinBy.Models
{
    public partial class Birthdays
    {
        public string Age => BirthDate?.Age(DateTime.Now).YearsMonthsDays;

        public string FullName => $"{FirstName} {LastName}";
    }
}
