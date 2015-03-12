using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BauchladenProgrammUnitTests
{
    [TestClass]
    public class ProduktVerwaltungTest
    {
        ProduktVerwaltung test = new ProduktVerwaltung();
 
        [TestInitialize]
        public void vorTest()
        {

        }
      
        [TestMethod]
        public void ProduktVerwaltung_ProduktHinzufuegenKorrekt()
        {
            test.produktHinzufuegen("Mars","lecker",0.50);
            Assert.AreEqual(1,test.anzahlProdukte());
            test.produktHinzufuegen("Mars", 0.50);
            Assert.AreEqual(2, test.anzahlProdukte());
        }
      
        [TestMethod]
        [ExpectedException(typeof(Exception), "Der Produktname muss mehr als zwei Zeichen enthalten")]
        public void ProduktVerwaltung_ProduktHinzufuegenFehler1()
        {
            test.produktHinzufuegen(null, "lecker", 0.50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Der Produktname muss mehr als zwei Zeichen enthalten")]
        public void ProduktVerwaltung_ProduktHinzufuegenFehler2()
        {
            test.produktHinzufuegen("Ma", "lecker", 0.50);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Der Produktpreis muss größer als 0 Euro sein")]
        public void ProduktVerwaltung_ProduktHinzufuegenFehler3()
        {
            test.produktHinzufuegen("Mars", "lecker", 0);
        }
    }
}
