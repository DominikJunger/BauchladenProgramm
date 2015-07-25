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
    }
}
