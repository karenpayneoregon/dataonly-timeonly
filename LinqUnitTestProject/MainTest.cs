using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FileLibrary.Classes;
using FileLibrary.Models;
using LinqUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.LINQ)]
        public void TestMethod1()
        {
            // arrange


            // act


            // assert
        }

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


    }
}
