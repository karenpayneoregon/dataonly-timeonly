using System;
using System.Diagnostics;
using System.Linq;
using FileLibrary.Classes;
using FileLibrary.LanguageExtensions;
using FileLibraryUnitTestProject.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileLibraryUnitTestProject
{
    [TestClass]
    public partial class MainTest : TestBase
    {
        [TestMethod]
        [TestTraits(Trait.DateOnly)]
        public void ReadPeopleTest()
        {
            var list = Operations.ReadPeople();

            Assert.AreEqual(list.Count, 20);
        }
        [TestMethod]
        [TestTraits(Trait.DateOnly)]
        public void ReadPeopleValidateDatesTest()
        {
            var list = Operations.ReadPeople();

            DateOnly firstRecordBirthDate = new(1963, 1, 15);
            DateOnly lastRecordBirthDate = new(1984, 10, 14);

            Assert.AreEqual(firstRecordBirthDate, list.First().BirthDate);
            Assert.AreEqual(lastRecordBirthDate, list.Last().BirthDate);

        }

        [TestMethod]
        [TestTraits(Trait.DateOnly)]
        public void SetTimeForBirthDateTest()
        {
            var list = Operations.ReadPeople();

            DateTime expected = new(1963, 1, 15, 1, 1, 0);

            var result = list.First().BirthDate.ToDateTime(1,1);

            Assert.AreEqual(result,expected);
            
        }

        [TestMethod]
        [TestTraits(Trait.DateOnly)]
        public void TryParseExactTest()
        {
            var dateValue = "09/01/2021";
            
            var expectedDateOnly = new DateOnly(2021, 9, 1);
            Assert.IsTrue(DateOnly.TryParseExact(dateValue, "MM/dd/yyyy", out var resultDateOnly));
            Assert.AreEqual(resultDateOnly, expectedDateOnly);
            
            DateOnly badDateOnly = new(1, 1, 1);
            DateOnly.TryParseExact(dateValue, "MM-dd-yyyy", out var resultDateOnly1);
            Assert.AreEqual(resultDateOnly1, badDateOnly);
            
        }

        [TestMethod]
        [TestTraits(Trait.DateOnly)]
        public void ToLongDateStringTest()
        {
            var dateOnly = new DateOnly(2021, 9, 1);

            Assert.AreEqual(DateLongFormatSeptember, dateOnly.ToLongDateString());

        }
        [TestMethod]
        [TestTraits(Trait.DateOnly)]
        public void ToShortDateStringTest()
        {
            var dateOnly = new DateOnly(2021, 9, 1);

            Assert.AreEqual(dateOnly.ToShortDateString(), DateShortFormatSeptember);
        }


    }
}
