using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BauchladenProgramm;

namespace BauchladenProgrammUnitTests
{
    [TestClass]
    public class _DoubleTest
    {
        [TestInitialize]
        public void vorTest()
        {
            
        }

        [TestMethod]
        public void DefaultKonstruktorTest()
        {
            _Double test = new _Double();
            Assert.AreEqual(0.00, test.Zahl);
        }

        [TestMethod]
        public void KonstruktorTest()
        {
            _Double test = new _Double(1.1);
            Assert.AreEqual(1.1, test.Zahl);
            _Double test1 = new _Double(200.11);
            Assert.AreEqual(200.11, test1.Zahl);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Zahl mit zu vielen Nachkommastellen")]
        public void AusnahmeTest()
        {
            _Double test = new _Double(3.222);
        }

    }
}
