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
            test = new Einkauf(new DateTime(2015, 3, 3));
        }
        [TestMethod]
        public void Einkauf_KonstruktorTest()
        {
            Assert.AreEqual(0.0, test.GesamtPreis.Zahl);
            Assert.AreEqual(new DateTime(2015, 3, 3), test.Datum);
        }

        [TestMethod]
        public void Einkauf_ProduktTest()
        {
            Assert.IsNotNull(test.Produkte);
        }
    }
}
