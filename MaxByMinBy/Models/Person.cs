using System;
using System.Text.Json.Serialization;
using HelperLibrary.JsonConverters;
using HelperLibrary.LanguageExtensions;

namespace MaxByMinBy.Models
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

        public override string ToString() 
            => $"{Id,-6:D2}{FirstName, -15} {LastName, -15} {BirthDate:MM/dd/yyyy}";

        protected bool Equals(Person other) => Id == other.Id && FirstName == other.FirstName && LastName == other.LastName;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Person)obj);
        }

        public override int GetHashCode() => HashCode.Combine(Id, FirstName, LastName);

        public static bool operator ==(Person left, Person right) => Equals(left, right);

        public static bool operator !=(Person left, Person right) => !Equals(left, right);
    }
}
