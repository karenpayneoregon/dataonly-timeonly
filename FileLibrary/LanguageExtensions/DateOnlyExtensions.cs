using System;

namespace FileLibrary.LanguageExtensions
{
    public static class DateOnlyExtensions
    {
        /// <summary>
        /// Create a new <see cref="DateTime"/> from a <see cref="DateOnly"/> without creating
        /// the <see cref="TimeOnly"/> in implementation 
        /// </summary>
        /// <param name="sender">DateOnly</param>
        /// <param name="hour">Hour to set for result DateTime</param>
        /// <param name="minutes">Minutes to set for result DateTime</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateOnly sender, int hour = 0, int minutes = 0)
            => sender.ToDateTime(new TimeOnly(hour, minutes));

    }
}