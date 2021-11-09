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
                // TimeOnly columns are only format for ease of reading
                Console.WriteLine($"{table.id, -4:D2}{table.FirstName,-12}{table.LastName,-12}{table.StartTime,-12:hh:mm tt}{table.EndTime,-12:hh:mm tt}");
            }
        }
    }
}
