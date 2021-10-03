using System;
using System.Text.Json.Serialization;
using FileLibrary.JsonConverters;
using FileLibrary.LanguageExtensions;

namespace FileLibrary.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Representation of <see cref="DateOnly"/> property <see cref="BirthDate"/>
        /// </summary>
        [JsonIgnore]
        public DateTime BirthDateAsDateTime
            => BirthDate.ToDateTime();
        public override string ToString() => $"{FirstName} {LastName} {BirthDate}";

    }
}
