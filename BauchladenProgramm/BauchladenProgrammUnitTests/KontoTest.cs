using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BauchladenProgramm;

namespace BauchladenProgrammUnitTests
{
    [TestClass]
    public class KontoTest
    {
        Konto test = null; 
        [TestInitialize]
        public void vorTest()
        {
            test = new Konto(); 
        }

        [TestMethod]
        public void KontostandInitialisiert()
        {
            Assert.AreEqual(new _Double(0.0), test.Kontostand);
        }
    }
}
