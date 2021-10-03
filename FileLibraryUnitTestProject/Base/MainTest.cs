using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FileLibrary.Models;


// ReSharper disable once CheckNamespace - do not change
namespace FileLibraryUnitTestProject
{
    public partial class MainTest
    {

        /// <summary>
        /// Wednesday, September 1, 2021
        /// </summary>
        protected string DateLongFormatSeptember => "Wednesday, September 1, 2021";
        protected string DateShortFormatSeptember => "9/1/2021";

        [TestInitialize]
        public void Initialization()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
    }
}
