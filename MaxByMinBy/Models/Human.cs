using System;
using System.Collections.Generic;

namespace MaxByMinBy.Models
{
    /// <summary>
    /// For demonstrating using MaxBy overload
    /// </summary>
    public class Human 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        private sealed class BirthDateRelationalComparer : IComparer<Human>
        {
            public int Compare(Human x, Human y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.BirthDate.CompareTo(y.BirthDate);
            }
        }

        public static IComparer<Human> BirthDateComparer { get; } = new BirthDateRelationalComparer();

    }
}
