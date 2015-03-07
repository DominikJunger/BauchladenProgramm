using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BauchladenProgramm;

namespace BauchladenProgrammUnitTests
{
    [TestClass]
    public class TeilnehmerTest
    {
        Teilnehmer test = null;
        Teilnehmer test1 = null;
        string vornamen = "Karl";
        string nachname = "Heinz";
        string wohnort = "Winter";
        DateTime geburtsdatum = new DateTime(2001, 3, 5);

        [TestInitialize]
        public void vorTest()
        {
            test = new Teilnehmer(vornamen, nachname, geburtsdatum, wohnort);
            test1 = new Teilnehmer(vornamen, nachname, geburtsdatum, wohnort);
        }
        
        [TestMethod]
        public void IdTest()
        {
            Assert.AreEqual(1, test.Id);
            Assert.AreEqual(2, test1.Id);
            Assert.AreEqual(false, test.Equals(test1));
        }

        [TestMethod]
        public void KonstruktorTest()
        {
            Assert.AreEqual("Karl",test.Vorname);
            Assert.AreEqual("Heinz", test.Nachname);
            Assert.AreEqual("Winter", test.Wohnort);
            Assert.AreEqual(new DateTime(2001, 3, 5), test.Geburtsdatum);
        }

        [TestMethod]
        public void KontoTest()
        {
            Assert.IsNotNull(test.Konto);
            Assert.IsNotNull(test1.Konto);
        }
    }
}
