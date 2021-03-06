﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BauchladenProgramm;
using BauchladenProgramm.Backend_Klassen;

namespace BauchladenProgrammUnitTests
{
    [TestClass]
    public class ProduktTest
    {
        [TestMethod]
        public void Produkt_Konstruktor3ArgumenteTest()
        {
            Produkt test = new Produkt("Apfel", "Sieht gut aus, ist aber gesund.", 1.00);
            Assert.AreEqual("Apfel",test.Name);
            Assert.AreEqual("Sieht gut aus, ist aber gesund.",test.Beschreibung);
            Assert.AreEqual(1.00, test.Preis.Zahl);
        }

        [TestMethod]
        public void Produkt_Konstruktor2ArgumenteTest()
        {
            Produkt test = new Produkt("Twix", 0.50);
            Assert.AreEqual("Twix", test.Name);           
            Assert.AreEqual(0.50, test.Preis.Zahl);
        }
    }
}
