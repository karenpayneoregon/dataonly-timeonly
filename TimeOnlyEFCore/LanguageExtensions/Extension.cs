using System;

namespace TimeOnlyEFCore.LanguageExtensions
{
    public static class Extension
    {
        public static TimeOnly ToTimeOnlyNullable(this TimeSpan? sender) =>
            sender.HasValue ? 
                new TimeOnly(sender.Value.Hours, sender.Value.Minutes) : 
                new TimeOnly(0, 0);

        public static TimeOnly ToTimeOnly(this TimeSpan sender) => new TimeOnly(sender.Hours, sender.Minutes);
    }
}