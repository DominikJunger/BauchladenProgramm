using System;
using BauchladenProgramm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BauchladenProgrammUnitTests
{
    [TestClass]
    public class EinkaufTest
    {
        Einkauf test = null;
        [TestInitialize]
        public void vorTest() 
        {
            test = new Einkauf(new _Double(230.50), new DateTime(2015, 3, 3));
        }
        [TestMethod]
        public void KonstruktorTest()
        {
           
            Assert.AreEqual(230.50, test.GesamtPreis.Zahl);
            Assert.AreEqual(new DateTime(2015, 3, 3), test.Datum);
        }

        [TestMethod]
        public void ProduktTest()
        {
            Assert.IsNotNull(test.Produkte);
        }
    }
}
