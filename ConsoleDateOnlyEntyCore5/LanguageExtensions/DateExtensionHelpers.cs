using System;
using System.Linq;
using DateOnlyEFCore.Models;

namespace DateOnlyEFCore.LanguageExtensions
{
    public static class DateExtensionHelpers
    {

        public static IQueryable<Birthdays> BirthDatesBetween(this IQueryable<Birthdays> events, DateTime startDate, DateTime endDate)
            => events.Where(@event
                => startDate <= @event.BirthDate && @event.BirthDate <= endDate);

    }
}
