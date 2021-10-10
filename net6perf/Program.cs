// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using net6perf.Classes;
using net6perf.ExtensionMethods;
using net6perf.Models;

namespace net6perf
{
    class Program   
    {
        private int[] _values = Enumerable.Range(0, 100_000).ToArray();
        [Benchmark]
        public int Find() => Find(_values, 99_999);

        private static int Find<T>(T[] array, T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], item))
                {
                    return i;
                }
            }

            return -1;
        }
        static void Main(string[] args)
        {
            PrependCategory();

        }

        private static void PrependCategory()
        {
            var categoriesList = JsonHelpers.DeserializeObject<List<Categories>>(File.ReadAllText("Categories.json"));

            IEnumerable<Categories> categories = 
                categoriesList.Prepend(
                    new Categories()
                    {
                        CategoryID = 0, 
                        CategoryName = "Select"
                    });


            foreach (var category in categories)
            {
                Debug.WriteLine($"{category.CategoryID,-4}{category.CategoryName}");
            }
        }
    }
}


