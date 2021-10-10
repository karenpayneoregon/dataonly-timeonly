﻿using System;
using HelperLibrary.LanguageExtensions;
using MaxByMinBy.LanguageExtensions;

#nullable disable

namespace MaxByMinBy.Models
{
    public partial class Birthdays
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateOnly? BirthDateOnly => BirthDate.ToDateOnly();
    }
}