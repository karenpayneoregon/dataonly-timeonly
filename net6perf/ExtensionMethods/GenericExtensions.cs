using System.Collections.Generic;
using System.Linq;

namespace net6perf.ExtensionMethods
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Prepend an element to list using <see cref="Enumerable.Prepend"/> which
        /// does not affect the original list which this extension does by creating
        /// a new list.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source</typeparam>
        /// <param name="sender">A sequence of values.</param>
        /// <param name="item">The value to prepend to source</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Prepend<TSource>(this List<TSource> sender, TSource item) 
            where TSource : new() => Enumerable.Prepend(sender, item);
    }
}