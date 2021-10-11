using System;
using System.Diagnostics;
using System.Linq;
using TimeOnlyEFCore.Data;

namespace TimeOnlyEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new Context();
            var results = context.TimeTable.ToList();

            foreach (var table in results)
            {
                Debug.WriteLine($"{table.id, -4:D2}{table.FirstName,-12}{table.LastName,-12}{table.Start,-12:hh:mm tt}{table.End,-12:hh:mm tt}");
            }
        }
    }
}
