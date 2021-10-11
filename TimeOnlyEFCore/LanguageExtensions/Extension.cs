using System;

namespace TimeOnlyEFCore.LanguageExtensions
{
    public static class Extension
    {
        public static TimeOnly TimeOnly(this TimeSpan? sender) =>
            sender.HasValue ? 
                new TimeOnly(sender.Value.Hours, sender.Value.Minutes) : 
                new TimeOnly(0, 0);
    }
}