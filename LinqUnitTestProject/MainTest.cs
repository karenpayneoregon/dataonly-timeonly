using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileLibrary.Classes;
using FileLibrary.Models;
using LinqUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqUnitTestProject
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public partial class MainTest : TestBase
    {

        #region https://dotnetcoretutorials.com/2021/08/12/ienumerable-chunk-in-net-6/?recap


        /// <summary>
        /// Given 20 people, chunk size as 5 expect four as count
        /// </summary>
        [TestMethod]
        [TestTraits(Trait.LINQ)]
        public void ChunkPeopleTest()
        {
            var list = Operations.ReadPeople();

            IEnumerable<Person[]> chunks = list.Chunk(5);

            Assert.AreEqual(chunks.Count(), 4);

        }

        #endregion

        [TestMethod]
        [TestTraits(Trait.LINQ)]
        public void LastPersonIndexTest()
        {
            var list = Operations.ReadPeople();

            var person = list.ElementAt(^1);

            Person expect = new ()
            {
                Id = 20, 
                FirstName = "Josh", 
                LastName = "James", 
                BirthDate = new DateOnly(1984,10,14)
            };

            Assert.AreEqual(person, expect);

        }

        /// <summary>
        /// Test Take/Skip
        /// </summary>
        /// <remarks>
        /// Most index/range examples will hard code values,
        /// here they are done by creating new index instances
        /// </remarks>
        [TestMethod]
        [TestTraits(Trait.LINQ)]
        public void EnumerableTakeSkipTest()
        {
            var list = Operations.ReadPeople();

            var takeIndex = new Index(2);
            var endIndex = new Index(6);

            // .NET Core 6
            var results1 = list.Take(takeIndex..endIndex).ToArray();

            // Prior syntax
            var results2 = list.Take(6).Skip(2).ToArray();

            CollectionAssert.AreEqual(results1,results2);

        }


        [TestMethod]
        [TestTraits(Trait.LINQ)]
        public void FirstOrDefaultLastOrDefaultOverloadTest()
        {

            var list = Operations.ReadPeople();

            Person person = list.FirstOrDefault();
            Assert.IsNotNull(person);

            list = new List<Person>();
            person = new () { Id = 100, FirstName = "Bob", LastName = "White" };
            person = list.FirstOrDefault(person);
            Assert.IsNotNull(person);

            Assert.IsNull(list.FirstOrDefault());

        }

        [TestMethod]
        [TestTraits(Trait.LINQ)]
        public void LastOrDefaultDefaultOverloadTest()
        {
            List<Person> list = new List<Person>();

            Assert.IsNull(list.FirstOrDefault());
            Assert.IsNotNull(list.FirstOrDefault(new Person()));

        }


        /// <summary>
        /// Testing PeriodicTimer and marked as ignore because it takes time to run
        /// </summary>
        /// <returns>Nothing</returns>
        [TestMethod]
        [Ignore]
        [TestTraits(Trait.Timers)]
        public async Task PeriodicTimerTest()
        {
            StringBuilder builder = new();
            
            int counter = 10;

            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            try
            {
                while (await timer.WaitForNextTickAsync())
                {
                    builder.AppendLine($"Time: {DateTime.UtcNow:hh:mm:ss tt}");

                    counter -= 1;
                    if (counter <= 1)
                    {
                        break;
                    }
                }

                Console.WriteLine(builder.ToString());
            }
            finally
            {
                timer.Dispose();
            }
        }
    }
}
