using BLL;
using Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class ManagerTests
    {
        [TestCase("6/1/2013","Orders_06012013")]
        [TestCase("12/30/2013", "Orders_12302013")]
        [TestCase("12/1/2013", "Orders_12012013")]

        public void CanConvertDateTimeToString(string dateString, string expected )
        {
            DateTime date = DateTime.Parse(dateString);
            Manager manager = ManagerFactory.Create();
            string result = manager.ConvertDateToString(date);

            Assert.AreEqual(expected, result);

        }

        [TestCase("Orders_06012013", true)]
        [TestCase("Orders_06022013", false)]

        public void CanCheckIfTestFileExists(string filePath, bool expected)
        {
            MockOrderRepo repo = new MockOrderRepo();
            bool result = repo.CheckFileExists(filePath);

            Assert.AreEqual(expected, result);
        }
    }
}
