using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//===========================
using iTextSharp.text;
using iTextSharp.text.pdf;
using BauchladenProgrammServer.Backend_Klassen;
//===========================

namespace BauchladenProgrammServer.Klassen
{
    public class PDFCreator
    {
        private Document doc;

        public PDFCreator(string path)
        {
            // neues Dokument erstellen
            doc = new Document();
            
            // Schriftart festlegen, Standardmäßig ist hier  Helvetica, 12pt, black, Normal festgelegt
            BaseFont courier = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
            iTextSharp.text.Font cou = new iTextSharp.text.Font(courier, 12, 0, iTextSharp.text.Color.BLACK);

            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
        }

        public void createAuszahlung(PDFAuszahlung aus)
        {
            doc.Open();

            doc.Add(new Paragraph("Abrechnung am "+  DateTime.Today.ToShortDateString()+ " des Teilnehmers: " + aus.El.Tn.VorName +" "+ aus.El.Tn.NachName+"\n\n"));

            PdfPTable table = new PdfPTable(4); 
            table.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cell = new PdfPCell(new Phrase("Gekaufte Produkte"));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;            
            table.AddCell(cell);

            // Neue Zellen hinzufügen
            table.AddCell(new Phrase("Datum"));
            table.AddCell(new Phrase("Produktname"));
            table.AddCell(new Phrase("Einzelpreis"));
            table.AddCell(new Phrase("Anzahl"));

            foreach(Einkauf e in aus.El.El)
            {
                table.AddCell(e.Date.ToString());
                table.AddCell(e.Pr.Name);
                table.AddCell(e.Pr.Preis.ToString());
                table.AddCell(e.Anzahl.ToString());
            }

            float[] culumsWidths = new float[] { 30f, 20f, 11f, 11f };
            table.SetWidths(culumsWidths);
            
            // Tabelle zum PDF hinzufügen und PDf Dokument schließen
            doc.Add(table);

            doc.Add(new Paragraph("\n\n"));

            PdfPTable tableEinzahlung = new PdfPTable(2);
            tableEinzahlung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellEinzahlung = new PdfPCell(new Phrase("Kontostände nach der Einzahlung"));
            cellEinzahlung.Colspan = 2;
            cellEinzahlung.HorizontalAlignment = 1;
            tableEinzahlung.AddCell(cellEinzahlung);

            // Neue Zellen hinzufügen
            tableEinzahlung.AddCell(new Phrase("Datum"));
            tableEinzahlung.AddCell(new Phrase("Kontostand"));


            foreach (Kontostand k in aus.Einzahlung)
            {
                tableEinzahlung.AddCell(k.Datum.ToString());
                tableEinzahlung.AddCell(k.Kstand.ToString());
            }

            doc.Add(tableEinzahlung);

            doc.Add(new Paragraph("\n\n"));

            PdfPTable tableAuszahlung = new PdfPTable(2);
            tableAuszahlung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellAuszahlung = new PdfPCell(new Phrase("Kontostände nach den einzelnen Käufen"));
            cellAuszahlung.Colspan = 2;
            cellAuszahlung.HorizontalAlignment = 1;
            tableAuszahlung.AddCell(cellAuszahlung);

            // Neue Zellen hinzufügen
            tableAuszahlung.AddCell(new Phrase("Datum"));
            tableAuszahlung.AddCell(new Phrase("Kontostand"));


            foreach (Kontostand k in aus.Auszahlung)
            {
                tableAuszahlung.AddCell(k.Datum.ToString());
                tableAuszahlung.AddCell(k.Kstand.ToString());
            }

            doc.Add(tableAuszahlung);

            doc.Add(new Paragraph("\n\n"));

            PdfPTable tableAuflistung = new PdfPTable(2);
            tableAuflistung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellAuflistung = new PdfPCell(new Phrase("Kontostände im Verlauf"));
            cellAuflistung.Colspan = 2;
            cellAuflistung.HorizontalAlignment = 1;
            tableAuflistung.AddCell(cellAuflistung);

            // Neue Zellen hinzufügen
            tableAuflistung.AddCell(new Phrase("Datum"));
            tableAuflistung.AddCell(new Phrase("Kontostand"));


            foreach (Kontostand k in aus.Auflistung)
            {
                tableAuflistung.AddCell(k.Datum.ToString());
                tableAuflistung.AddCell(k.Kstand.ToString());
            }

            doc.Add(tableAuflistung);

            doc.Add(new Paragraph("\n\n"));
            doc.Add(new Paragraph("\n\n"));

            if (aus.Auflistung.Count>0)
            {
                doc.Add(new Paragraph("Betrag der Ausgezahlt wird: " + aus.Auflistung[aus.Auflistung.Count - 1].Kstand + " €"));
            }
            else
            {
                doc.Add(new Paragraph("Betrag der Ausgezahlt wird: 0,00 €"));
            }
            doc.Close();
        }
        public void createStückelung(List<Teilnehmer> tn)
        {
            int count50=0;
            int count20=0;
            int count10=0;
            int count5=0;
            int count2=0;
            int count1=0;
            int count0_50=0;
            int count0_20=0;
            int count0_10=0;
            int count0_05=0;
            int count0_02=0;
            int count0_01=0;

            int count2R=0;
            int count1R = 0;
            int count0_50R = 0;
            int count0_20R = 0;
            int count0_10R = 0;
            int count0_05R = 0;
            int count0_02R = 0;
            int count0_01R = 0;

            foreach (Teilnehmer t in tn)
            {
                decimal tmpKontostand=decimal.Parse(t.Kontostand.ToString());

                count50+=(int) t.Kontostand / 50;
                tmpKontostand-= 50*((int) t.Kontostand / 50);
                count20 += (int)tmpKontostand / 20;
                tmpKontostand -= 20 * ((int)tmpKontostand / 20);
                count10 += (int)tmpKontostand / 10;
                tmpKontostand -= 10 * ((int)tmpKontostand / 10);
                count5 += (int)tmpKontostand / 5;
                tmpKontostand -= 5 * ((int)tmpKontostand / 5);
                count2 += (int)tmpKontostand / 2;
                tmpKontostand -= 2 * ((int)tmpKontostand / 2);
                count1 += (int)tmpKontostand / 1;
                tmpKontostand -= 1 * ((int)tmpKontostand / 1);
                count0_50 += (int)(tmpKontostand / (decimal)0.50);
                tmpKontostand -= (decimal)0.50 * ((int)(tmpKontostand / (decimal)0.50));
                count0_20 += (int)(tmpKontostand / (decimal)0.20);
                tmpKontostand -= (decimal)0.20 * ((int)(tmpKontostand / (decimal)0.20));
                count0_10 += (int)(tmpKontostand / (decimal)0.10);
                tmpKontostand -= (decimal)0.10 * ((int)(tmpKontostand / (decimal)0.10));
                count0_05 += (int)(tmpKontostand / (decimal)0.05);
                tmpKontostand -= (decimal)0.05 * ((int)(tmpKontostand / (decimal)0.05));
                count0_02 += (int)(tmpKontostand / (decimal)0.02);
                tmpKontostand -= (decimal)0.02 * ((int)(tmpKontostand / (decimal)0.02));
                count0_01 += (int)(tmpKontostand / (decimal)0.01);
                tmpKontostand -= (decimal)0.01 * ((int)(tmpKontostand / (decimal)0.01));
                if (tmpKontostand > 0)
                {
                    throw new Exception("Fehler bei der Stückelung");
                }
            }

            if(count2>25)
            {
                count2R = count2 / 25;
                count2 = (count2 % 25);
            }
            if (count1 > 25)
            {
                count1R = count1 / 25;
                count1 = (count1 % 25);
            }

            if (count0_50 > 40)
            {
                count0_50R = count0_50 / 40;
                count0_50 =(count0_50 % 40);
            }

            if (count0_20 > 40)
            {
                count0_20R = count0_20 / 40;
                count0_20 = (count0_20 % 40);
            }

            if (count0_10 > 40)
            {
                count0_10R = count0_10 / 40;
                count0_10 = (count0_10 % 40);
            }

            if (count0_05 > 50)
            {
                count0_05R = count0_05 / 50;
                count0_05 = (count0_05 % 50);
            }

            if (count0_02 > 50)
            {
                count0_02R = count0_02 / 50;
                count0_02 = (count0_02 % 50);
            }

            if (count0_01 > 50)
            {
                count0_01R = count0_01 / 50;
                count0_01 = (count0_01 % 50);
            }

            doc.Open();

            doc.Add(new Paragraph("Aktuelle Stückelung (Stand: " + DateTime.Now.ToString() + ")\n\n"));

            PdfPTable table = new PdfPTable(4);
            table.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts


            // Neue Zellen hinzufügen
            table.AddCell(new Phrase("AnzahlRollen"));
            table.AddCell(new Phrase("WerteRollen"));
            table.AddCell(new Phrase("Anzahl"));
            table.AddCell(new Phrase("Werte"));

            table.AddCell("");
            table.AddCell("");
            table.AddCell(count50.ToString());
            table.AddCell("50€");
            table.AddCell("");
            table.AddCell("");
            table.AddCell(count20.ToString());
            table.AddCell("20€");
            table.AddCell("");
            table.AddCell("");
            table.AddCell(count10.ToString());
            table.AddCell("10€");
            table.AddCell("");
            table.AddCell("");
            table.AddCell(count5.ToString());
            table.AddCell("5€");

            table.AddCell(count2R.ToString());
            table.AddCell("2€x25");
            table.AddCell(count2.ToString());
            table.AddCell("2€");

            table.AddCell(count1R.ToString());
            table.AddCell("1€x25");
            table.AddCell(count1.ToString());
            table.AddCell("1€");

            table.AddCell(count0_50R.ToString());
            table.AddCell("0.50€x40");
            table.AddCell(count0_50.ToString());
            table.AddCell("0.50€");

            table.AddCell(count0_20R.ToString());
            table.AddCell("0.20€x40");
            table.AddCell(count0_20.ToString());
            table.AddCell("0.20€");

            table.AddCell(count0_10R.ToString());
            table.AddCell("0.10€x40");
            table.AddCell(count0_10.ToString());
            table.AddCell("0.10€");

            table.AddCell(count0_05R.ToString());
            table.AddCell("0.05€x50");
            table.AddCell(count0_05.ToString());
            table.AddCell("0.05€");

            table.AddCell(count0_02R.ToString());
            table.AddCell("0.02€x50");
            table.AddCell(count0_02.ToString());
            table.AddCell("0.02€");

            table.AddCell(count0_01R.ToString());
            table.AddCell("0.01€x50");
            table.AddCell(count0_01.ToString());
            table.AddCell("0.01€");

            doc.Add(table);
            doc.Close();
        }
        public void createTagesabschluss(PDFAuszahlung aus)
        {
            doc.Open();

            doc.Add(new Paragraph("Tagesabschluss am "+ DateTime.Now.Date.ToShortDateString() +" des Teilnehmers: " + aus.El.Tn.VorName + " " + aus.El.Tn.NachName + "\n\n"));

            PdfPTable table = new PdfPTable(4);
            table.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cell = new PdfPCell(new Phrase("Bisher gekaufte Produkte"));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            // Neue Zellen hinzufügen
            table.AddCell(new Phrase("Datum"));
            table.AddCell(new Phrase("Produktname"));
            table.AddCell(new Phrase("Einzelpreis"));
            table.AddCell(new Phrase("Anzahl"));

            foreach (Einkauf e in aus.El.El)
            {
                table.AddCell(e.Date.ToString());
                table.AddCell(e.Pr.Name);
                table.AddCell(e.Pr.Preis.ToString());
                table.AddCell(e.Anzahl.ToString());
            }

            float[] culumsWidths = new float[] { 30f, 20f, 11f, 11f };
            table.SetWidths(culumsWidths);

            // Tabelle zum PDF hinzufügen und PDf Dokument schließen
            doc.Add(table);

            doc.Add(new Paragraph("\n\n"));

            PdfPTable tableEinzahlung = new PdfPTable(2);
            tableEinzahlung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellEinzahlung = new PdfPCell(new Phrase("Kontostände nach der Einzahlung"));
            cellEinzahlung.Colspan = 2;
            cellEinzahlung.HorizontalAlignment = 1;
            tableEinzahlung.AddCell(cellEinzahlung);

            // Neue Zellen hinzufügen
            tableEinzahlung.AddCell(new Phrase("Datum"));
            tableEinzahlung.AddCell(new Phrase("Kontostand"));


            foreach (Kontostand k in aus.Einzahlung)
            {
                tableEinzahlung.AddCell(k.Datum.ToString());
                tableEinzahlung.AddCell(k.Kstand.ToString());
            }

            doc.Add(tableEinzahlung);

            doc.Add(new Paragraph("\n\n"));

            PdfPTable tableAuszahlung = new PdfPTable(2);
            tableAuszahlung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellAuszahlung = new PdfPCell(new Phrase("Kontostände nach den einzelnen Käufen"));
            cellAuszahlung.Colspan = 2;
            cellAuszahlung.HorizontalAlignment = 1;
            tableAuszahlung.AddCell(cellAuszahlung);

            // Neue Zellen hinzufügen
            tableAuszahlung.AddCell(new Phrase("Datum"));
            tableAuszahlung.AddCell(new Phrase("Kontostand"));


            foreach (Kontostand k in aus.Auszahlung)
            {
                tableAuszahlung.AddCell(k.Datum.ToString());
                tableAuszahlung.AddCell(k.Kstand.ToString());
            }

            doc.Add(tableAuszahlung);

            doc.Add(new Paragraph("\n\n"));

            PdfPTable tableAuflistung = new PdfPTable(2);
            tableAuflistung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellAuflistung = new PdfPCell(new Phrase("Kontostände im Verlauf"));
            cellAuflistung.Colspan = 2;
            cellAuflistung.HorizontalAlignment = 1;
            tableAuflistung.AddCell(cellAuflistung);

            // Neue Zellen hinzufügen
            tableAuflistung.AddCell(new Phrase("Datum"));
            tableAuflistung.AddCell(new Phrase("Kontostand"));


            foreach (Kontostand k in aus.Auflistung)
            {
                tableAuflistung.AddCell(k.Datum.ToString());
                tableAuflistung.AddCell(k.Kstand.ToString());
            }

            doc.Add(tableAuflistung);
            doc.Close();
        }
        public void createTagesabschlussAlle(List<PDFAuszahlung> aus)
        {
            doc.Open();

            doc.Add(new Paragraph("Gesamt Tagesabschluss am " + DateTime.Now.Date.ToShortDateString() + "\n\n"));

            PdfPTable tableAuflistung = new PdfPTable(3);
            tableAuflistung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // "Überschriften" Zelle einfügen
            PdfPCell cellAuflistung = new PdfPCell(new Phrase("Kontostände im Verlauf"));
            cellAuflistung.Colspan = 3;
            cellAuflistung.HorizontalAlignment = 1;
            tableAuflistung.AddCell(cellAuflistung);

            // Neue Zellen hinzufügen
            tableAuflistung.AddCell(new Phrase("Teilnehmer"));
            tableAuflistung.AddCell(new Phrase("Datum"));
            tableAuflistung.AddCell(new Phrase("Kontostand"));

            decimal sum=0;
            foreach (PDFAuszahlung pdf in aus)
            {
                tableAuflistung.AddCell(pdf.El.Tn.VorName + " "+pdf.El.Tn.NachName);
                tableAuflistung.AddCell(pdf.Auflistung[pdf.Auflistung.Count-1].Datum.ToString());
                tableAuflistung.AddCell(pdf.Auflistung[pdf.Auflistung.Count-1].Kstand.ToString());
                sum += pdf.Auflistung[pdf.Auflistung.Count - 1].Kstand;
            }

            doc.Add(tableAuflistung);

            doc.Add(new Paragraph("Aktueller Gesamtkontostand: "+sum.ToString() + " €"));

            doc.Close();
        }
        public void createStatistik(List<PDF_Produkt> p)
        {
            doc.Open();

            doc.Add(new Paragraph("Statistik der verkauften Produkte vom: " + DateTime.Now.Date.ToShortDateString() + "\n\n"));

            PdfPTable tableAuflistung = new PdfPTable(3);
            tableAuflistung.HorizontalAlignment = 0; // 0 = Links, 1 = Mitte, 2 = Rechts

            // Neue Zellen hinzufügen
            tableAuflistung.AddCell(new Phrase("Produkt"));
            tableAuflistung.AddCell(new Phrase("Einzelpreis"));
            tableAuflistung.AddCell(new Phrase("Anzahl verkauft"));

            decimal sum = 0;
            foreach (PDF_Produkt pdf in p)
            {
                tableAuflistung.AddCell(pdf.Name);
                tableAuflistung.AddCell(pdf.Preis.ToString());
                tableAuflistung.AddCell(pdf.Anzahl.ToString());
            }

            doc.Add(tableAuflistung);

            doc.Close();

        }
    }
}
