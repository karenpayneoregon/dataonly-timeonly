using System;
using System.ComponentModel.DataAnnotations.Schema;
using TimeOnlyEFCore.LanguageExtensions;

#nullable disable

namespace TimeOnlyEFCore.Models
{
    public partial class TimeTable
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
    }
}